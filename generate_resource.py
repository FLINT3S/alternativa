import os
import xml

import xml.etree.ElementTree as ET

import argparse
import uuid


def _rreplace(s, old, new, occurrence):
    l = s.rsplit(old, occurrence)
    return new.join(l)


def generate_server_resource(resource_name):
    RESOURCES_PATH = "dotnet/resources"
    CURRENT_RESOURCE_PATH = os.path.join(RESOURCES_PATH, resource_name)

    if os.path.exists(CURRENT_RESOURCE_PATH):
        print("Resource already exists")
        exit(1)

    try:
        os.makedirs(f"{CURRENT_RESOURCE_PATH}")
    except Exception as e:
        print("Error creating resource directory: ", e)
        exit(1)

    # region Generate resource files
    with open(f"{CURRENT_RESOURCE_PATH}/{resource_name}.cs", "w+") as f:
        f.write("""using GTANetworkAPI;

    namespace %s
    {
    public class Main : Script
        {

        }
    }
    """ % resource_name)

    with open(f"{CURRENT_RESOURCE_PATH}/{resource_name}.csproj", "w+") as f:
        f.write(r"""<Project Sdk="Microsoft.NET.Sdk">
        <PropertyGroup>
            <TargetFramework>netcoreapp3.1</TargetFramework>
            <Configurations>Debug</Configurations>
            <Platforms>x64</Platforms>
        </PropertyGroup>

        <ItemGroup>
          <Reference Include="Bootstrapper">
            <HintPath>..\..\runtime\Bootstrapper.dll</HintPath>
          </Reference>
        </ItemGroup>
    </Project>    
    """)

    with open(f"{CURRENT_RESOURCE_PATH}/meta.xml", "w+") as f:
        f.write(r"""<meta>
        <info name="%s" type="script" version="0.0.1"/>
        <script src="bin/x64/Debug/netcoreapp3.1/%s.dll"/>
    </meta>
    """ % (resource_name, resource_name))

    # add new project to solution resources.sln
    with open(f"{RESOURCES_PATH}/resources.sln", "r") as r:
        project_uuid = str(uuid.uuid4()).upper()
        config_uuid = str(uuid.uuid4()).upper()

        new_project_config = """EndProject
Project("{{{project_uuid}}}") = "{resource_name}", "{resource_name}\{resource_name}.csproj", "{{{config_uuid}}}"
EndProject""".format(
            project_uuid=project_uuid,
            config_uuid=config_uuid,
            resource_name=resource_name
        )

        new_project_build = """    {{{config_uuid}}}.Debug|x64.ActiveCfg = Debug|x64
        {{{config_uuid}}}.Debug|x64.Build.0 = Debug|x64
EndGlobalSection""".format(config_uuid=config_uuid)

        solution_text = r.read()
        solution_text = _rreplace(solution_text, "EndProject", new_project_config, 1)
        solution_text = _rreplace(solution_text, "EndGlobalSection", new_project_build, 1)

        with open(f"{RESOURCES_PATH}/resources.sln", "w") as f:
            f.write(solution_text)
    # endregion

    try:
        tree = ET.parse("dotnet/settings.xml")
        root = tree.getroot()

        root.append(ET.Element("resource", src=resource_name))
        tree.write("dotnet/settings.xml")
    except Exception as e:
        print("Error adding resource to settings.xml: ", e)
        print("Deleting resource directory")
        os.rmdir(CURRENT_RESOURCE_PATH)
        exit(1)

    print(f"Resource '{resource_name}' created successfully")


if __name__ == '__main__':
    parser = argparse.ArgumentParser(description='Tools to manage resources')
    parser.add_argument('command',
                        type=str,
                        nargs=1,
                        help='Command to execute:\n'
                             'gsr - Generate server resource\n'
                             'gcr - Generate client resource')
    parser.add_argument('resource_name', type=str, nargs=1, help='Resource name')
    args = parser.parse_args()

    if args.command[0] == "gsr":
        generate_server_resource(args.resource_name[0])
