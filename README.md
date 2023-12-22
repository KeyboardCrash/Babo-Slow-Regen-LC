# Babo Slow Regen LC
 Slow health regeneration mod for Lethal Company

 Introduces a health regeneration and battery regeneration mechanic to the game.

 Was done as a mini project to learn how to decompile C# projects and patch them on-the-fly with a mod loader.

 Is required by the game host as we send RPC's to each client. Recommended for all clients to have the mod however untested with just the host having the mod.

# Requirements
 Mod was written to use the BepInEx loader. Please compile and add to BepPinEx plugin folder

# Information
 The mod will take into consideration the following information:
  * Each game lasts approximately 11 minutes which is 660 ticks

 Batteries will regenerate at half their consumption rate while turned off
 * If a flashlight has 285 ticks of charge, it will take 570 ticks to fully recharge
 * A pro flashlight can last about 8 minutes a day with default regen values
 
 Health will regenerate at the following rates:
 * 1hp per tick below 20hp
 * 1hp per two ticks below 50hp
 * 1hp per three ticks below 75hp
 * To regenerate to full will take approximately ~2 minutes


# Balancing
 Obviously this will make the game easier, but some things can be done to balance the mod for more difficulty
 * Add a config folder to modify values without recompiling the project
 * Reduce the base energy regeneration so that there's still risk of battery running out before leaving the facility
 * Reduce HP regen or tweak it to time updates rather than tick updates