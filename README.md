# Spark
⚡️ Simple effect system for Unity

## TODO

* Byta ut strängar mot typer. scriptable objects
* Hantera procent eller floats i unit stats
* Hook up health and mana bar

### Improvments
* Add Abilities? 
* Create TimedStatusEffect and ChargedStatusEffect

### Create Script to generate Triggers and StatTypes
* Fix Paths to templates

### Items
* no weapon / starting weapon. regular attack -> gain x mana
* shives. attack twice. - to mana and damage
* wand. gain x+ mana

// Stamina - Max Health
public UnitStat Stamina = new UnitStat(100);

// Damage
// Health regeneration
// Magic Resitance
public UnitStat Strength = new UnitStat(10);

// Crit
// Evation
// Speed
// Armor
public UnitStat Agility = new UnitStat(10);

// Spell Damage
// Max Mana
// Mana reg
public UnitStat Intelligence = new UnitStat(10);
