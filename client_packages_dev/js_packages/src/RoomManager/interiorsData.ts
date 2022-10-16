const onlineAparts = [
  {name: "Modern 1 Apartment", key: '"apa_v_mp_h_01_a"', coords: [-786.8663, 315.7642, 217.6385]},
  {name: "Modern 2 Apartment", key: '"apa_v_mp_h_01_c"', coords: [-786.9563, 315.6229, 187.9136]},
  {name: "Modern 3 Apartment", key: '"apa_v_mp_h_01_b"', coords: [-774.0126, 342.0428, 196.6864]},
  {name: "Mody 1 Apartment", key: '"apa_v_mp_h_02_a"', coords: [-787.0749, 315.8198, 217.6386]},
  {name: "Mody 2 Apartment", key: '"apa_v_mp_h_02_c"', coords: [-786.8195, 315.5634, 187.9137]},
  {name: "Mody 3 Apartment", key: '"apa_v_mp_h_02_b"', coords: [-774.1382, 342.0316, 196.6864]},
  {name: "Vibrant 1 Apartment", key: '"apa_v_mp_h_03_a"', coords: [-786.6245, 315.6175, 217.6385]},
  {name: "Vibrant 2 Apartment", key: '"apa_v_mp_h_03_c"', coords: [-786.9584, 315.7974, 187.9135]},
  {name: "Vibrant 3 Apartment", key: '"apa_v_mp_h_03_b"', coords: [-774.0223, 342.1718, 196.6863]},
  {name: "Sharp 1 Apartment", key: '"apa_v_mp_h_04_a"', coords: [-787.0902, 315.7039, 217.6384]},
  {name: "Sharp 2 Apartment", key: '"apa_v_mp_h_04_c"', coords: [-787.0155, 315.7071, 187.9135]},
  {name: "Sharp 3 Apartment", key: '"apa_v_mp_h_04_b"', coords: [-773.8976, 342.1525, 196.6863]},
  {name: "Monochrome 1 Apartment", key: '"apa_v_mp_h_05_a"', coords: [-786.9887, 315.7393, 217.6386]},
  {name: "Monochrome 2 Apartment", key: '"apa_v_mp_h_05_c"', coords: [-786.8809, 315.6634, 187.9136]},
  {name: "Monochrome 3 Apartment", key: '"apa_v_mp_h_05_b"', coords: [-774.0675, 342.0773, 196.6864]},
  {name: "Seductive 1 Apartment", key: '"apa_v_mp_h_06_a"', coords: [-787.1423, 315.6943, 217.6384]},
  {name: "Seductive 2 Apartment", key: '"apa_v_mp_h_06_c"', coords: [-787.0961, 315.815, 187.9135]},
  {name: "Seductive 3 Apartment", key: '"apa_v_mp_h_06_b"', coords: [-773.9552, 341.9892, 196.6862]},
  {name: "Regal 1 Apartment", key: '"apa_v_mp_h_07_a"', coords: [-787.029, 315.7113, 217.6385]},
  {name: "Regal 2 Apartment", key: '"apa_v_mp_h_07_c"', coords: [-787.0574, 315.6567, 187.9135]},
  {name: "Regal 3 Apartment", key: '"apa_v_mp_h_07_b"', coords: [-774.0109, 342.0965, 196.6863]},
  {name: "Aqua 1 Apartment", key: '"apa_v_mp_h_08_a"', coords: [-786.9469, 315.5655, 217.6383]},
  {name: "Aqua 2 Apartment", key: '"apa_v_mp_h_08_c"', coords: [-786.9756, 315.723, 187.9134]},
  {name: "Aqua 3 Apartment", key: '"apa_v_mp_h_08_b"', coords: [-774.0349, 342.0296, 196.6862]}
]

const offices = [
  {name: "Executive Rich", key: '"ex_dt1_02_office_02b"', coords: [-141.1987, -620.913, 168.8205]},
  {name: "Executive Cool", key: '"ex_dt1_02_office_02c"', coords: [-141.5429, -620.9524, 168.8204]},
  {name: "Executive Contrast", key: '"ex_dt1_02_office_02a"', coords: [-141.2896, -620.9618, 168.8204]},
  {name: "Old Spice Warm", key: '"ex_dt1_02_office_01a"', coords: [-141.4966, -620.8292, 168.8204]},
  {name: "Old Spice Classical", key: '"ex_dt1_02_office_01b"', coords: [-141.3997, -620.9006, 168.8204]},
  {name: "Old Spice Vintage", key: '"ex_dt1_02_office_01c"', coords: [-141.5361, -620.9186, 168.8204]},
  {name: "Power Broker Ice", key: '"ex_dt1_02_office_03a"', coords: [-141.392, -621.0451, 168.8204]},
  {name: "Power Broker Conservative", key: '"ex_dt1_02_office_03b"', coords: [-141.1945, -620.8729, 168.8204]},
  {name: "Power Broker Polished", key: '"ex_dt1_02_office_03c"', coords: [-141.4924, -621.0035, 168.8205]},
  {name: "Garage 1", key: '"imp_dt1_02_cargarage_a"', coords: [-191.0133, -579.1428, 135.0000]},
  {name: "Garage 2", key: '"imp_dt1_02_cargarage_b"', coords: [-117.4989, -568.1132, 135.0000]},
  {name: "Garage 3", key: '"imp_dt1_02_cargarage_c"', coords: [-136.0780, -630.1852, 135.0000]},
  {name: "Mod Shop", key: '"imp_dt1_02_modgarage"', coords: [-146.6166, -596.6301, 166.0000]}
]

const offices2 = [
  {
    name: "Executive Rich",
    key: '"ex_dt1_11_office_02b"',
    coords: [-75.8466, -826.9893, 243.3859],
  },
  {
    name: "Executive Cool",
    key: '"ex_dt1_11_office_02c"',
    coords: [-75.49945, -827.05, 243.386],
  },
  {
    name: "Executive Contrast",
    key: '"ex_dt1_11_office_02a"',
    coords: [-75.49827, -827.1889, 243.386],
  },
  {
    name: "Old Spice Warm",
    key: '"ex_dt1_11_office_01a"',
    coords: [-75.44054, -827.1487, 243.3859],
  },
  {
    name: "Old Spice Classical",
    key: '"ex_dt1_11_office_01b"',
    coords: [-75.63942, -827.1022, 243.3859],
  },
  {
    name: "Old Spice Vintage",
    key: '"ex_dt1_11_office_01c"',
    coords: [-75.47446, -827.2621, 243.386],
  },
  {
    name: "Power Broker Ice",
    key: '"ex_dt1_11_office_03a"',
    coords: [-75.56978, -827.1152, 243.3859],
  },
  {
    name: "Power Broker Conservative",
    key: '"ex_dt1_11_office_03b"',
    coords: [-75.51953, -827.0786, 243.3859],
  },
  {
    name: "Power Broker Polished",
    key: '"ex_dt1_11_office_03c"',
    coords: [-75.41915, -827.1118, 243.3858],
  },
  {
    name: "Garage 1",
    key: '"imp_dt1_11_cargarage_a"',
    coords: [-84.2193, -823.0851, 221.0000],
  },
  {
    name: "Garage 2",
    key: '"imp_dt1_11_cargarage_b"',
    coords: [-69.8627, -824.7498, 221.0000],
  },
  {
    name: "Garage 3",
    key: '"imp_dt1_11_cargarage_c"',
    coords: [-80.4318, -813.2536, 221.0000],
  },
  {
    name: "Mod Shop",
    key: '"imp_dt1_11_modgarage"',
    coords: [-73.9039, -821.6204, 284.0000],
  }
]

const offices3 = [
  {
    name: "Executive Rich",
    key: '"ex_sm_13_office_02b"',
    coords: [-1579.756, -565.0661, 108.523],
  },
  {
    name: "Executive Cool",
    key: '"ex_sm_13_office_02c"',
    coords: [-1579.678, -565.0034, 108.5229],
  },
  {
    name: "Executive Contrast",
    key: '"ex_sm_13_office_02a"',
    coords: [-1579.583, -565.0399, 108.5229],
  },
  {
    name: "Old Spice Warm",
    key: '"ex_sm_13_office_01a"',
    coords: [-1579.702, -565.0366, 108.5229],
  },
  {
    name: "Old Spice Classical",
    key: '"ex_sm_13_office_01b"',
    coords: [-1579.643, -564.9685, 108.5229],
  },
  {
    name: "Old Spice Vintage",
    key: '"ex_sm_13_office_01c"',
    coords: [-1579.681, -565.0003, 108.523],
  },
  {
    name: "Power Broker Ice",
    key: '"ex_sm_13_office_03a"',
    coords: [-1579.677, -565.0689, 108.5229],
  },
  {
    name: "Power Broker Conservative",
    key: '"ex_sm_13_office_03b"',
    coords: [-1579.708, -564.9634, 108.5229],
  },
  {
    name: "Power Broker Polished",
    key: '"ex_sm_13_office_03c"',
    coords: [-1579.693, -564.8981, 108.5229],
  },
  {
    name: "Garage 1",
    key: '"imp_sm_13_cargarage_a"',
    coords: [-1581.1120, -567.2450, 85.5000],
  },
  {
    name: "Garage 2",
    key: '"imp_sm_13_cargarage_b"',
    coords: [-1568.7390, -562.0455, 85.5000],
  },
  {
    name: "Garage 3",
    key: '"imp_sm_13_cargarage_c"',
    coords: [-1563.5570, -574.4314, 85.5000],
  },
  {
    name: "Mod Shop",
    key: '"imp_sm_13_modgarage"',
    coords: [-1578.0230, -576.4251, 104.2000],
  }
]

export const allInteriors: Array<{coords: number[], name: string, key: string}> = [
  ...onlineAparts,
  ...offices,
  ...offices2,
  ...offices3,
]

