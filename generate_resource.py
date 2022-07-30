import os
import xml

import xml.etree.ElementTree as ET

resource_name = input()
try:
    os.makedirs("resources")
except Exception as e:
    pass

try:
    os.makedirs(f"resources/{resource_name}")
except Exception as e:
    pass


with open(f"resources/{resource_name}/{resource_name}.cs", "w+") as f:
    f.write("""using GTANetworkAPI;

namespace %s
{
public class Main : Script
    {

    }
}
""" % resource_name)

with open(f"resources/{resource_name}/{resource_name}.cproj", "w+") as f:
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

with open(f"resources/{resource_name}/meta.xml", "w+") as f:
    f.write(r"""<meta>
    <info name="%s" type="script"/>
    <script src="bin/x64/Debug/netcoreapp3.1/<newResource>.dll"/>
</meta>
""" % resource_name)


tree = ET.parse("dotnet/settings.xml")
root = tree.getroot()

try:
    root.remove(root.find("resource"))
except Exception as e:
    print(e)
resource = ET.Element("resource")
resource.set("src", resource_name)
root.append(resource)

tree.write("dotnet/settings.xml")
