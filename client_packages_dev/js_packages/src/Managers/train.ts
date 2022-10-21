const models = ["freight", "freightcar", "freightgrain", "freightcont1", "freightcont2",
  "freighttrailer", "tankercar", "metrotrain", "s_m_m_lsmetro_01"]

models.forEach((model) => {
  mp.game.streaming.requestModel(mp.game.joaat(model));
})

// 1838.1046142578125, 3528.820556640625, 38.384864807128906

const train = mp.game.vehicle.createMissionTrain(4, 1838.1046142578125, 3528.820556640625, 38.384864807128906, true)


// variation 20 или 21 - это трамвай для метро
