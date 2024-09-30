*** The app itself can be run by going to \bin\Release\net6.0-windows\Carnage.exe. Please note this project is being updated continuously and therefore will always be a work-in-progress. *** 

Carnage: A Hunger Games Simulator was created by Patrick Valsted as his Bellarmine University Software and Data Engineering capstone project. It has been updated multiple times after the capstone's completion, including this major update (of which you can find the changelog below). 

Carnage 1.1 Changelog: please visit https://docs.google.com/document/d/11oL51tufNSVDds1lBo2qGfFj8SrZLJBD8LiQUbZoeHI/ for the formatted changelog or view the rough version below


Additions

Added Status Effects, which can affect the outcome of battles
  - Inflicted on a character by an enemy’s weapon
  - Burning and Poison can kill a character
  - Burning: Every time after a character attacks, they take 1-2 damage
    - Has a 30% chance to expire every time
    - Cannot be inflicted while it’s raining
  - Poison: Every time after a character attacks, they have a 30% chance to take 2-3 damage
    - The effect is permanent and can only go away if a player has an antidote. However, they will only take damage from this during battles.
    - Antidotes were added to the already-existing loot table and can be found commonly. A character can also find herbs during day-to-day events that serve the same purpose. They can be stored for later use just like healing items if
      the character doesn’t need them right away.
    - A character will only use their antidote in battle if they are close to death (below 8 health) or their opponent is defeated. This is so they won’t immediately be inflicted with poison again right after using it.
  - Freeze: Non-damaging effect that hinders a character in several ways
    - A character cannot flee while frozen, and an opponent can flee with 100% success against someone who’s frozen
    - A character’s speed is lowered by 2 until the effect wears off
    - A character has a 20% chance of missing an attack if they were going to attack their opponent
    - Freeze has a 50% chance of wearing off at the end of every battle
Added the Forest Imp Encampment landmark for characters to explore alongside the temple and watchtower that already exist
  - Like the previous two landmarks this event is built using 3 different blocks of text
  - Unlike the previous two landmarks, which had set outcomes, this event uses randomness to determine whether things happen each time the 3 blocks of text are generated
    - The first block of text corresponds to the character discovering the landmark, and they have a 25% chance to turn back instead of moving on
    - The second block of text corresponds to the character examining their surroundings inside the encampment, and the character has a 20% chance of getting caught by a Forest Imp Patrol and having to battle them
    - This NPC has 6-10 health and a blowgun that can inflict poison
    - The NPC has a 50% chance of having an antidote on them
    - The final block of text corresponds to the outcome of this venture, which could be one of four things that can help (or harm) the character. Just like the segment before, the character has another 20% chance of getting caught and
      having to battle
  - The character can imbue their weapon with a status effect or find rare loot among other outcomes, if they make it that far
Added rain, which has a 10% chance of happening at the beginning of each day
  - While raining, characters each have a 30% chance of missing their attack if they were going to successfully attack
  - Characters cannot be inflicted with burning in the rain, and if they have it the effect wears off
  - Rain automatically subsides at the end of each day
Added the option to cure status effects and imbue weapons with effects on the sponsor screen
Added the Sorcerer’s Staff, which can be found only in the watchtower after defeating The Living Dummy
  - Does 4 damage, and comes with one random status effect
  - The character will either find the staff or a random rare loot after defeating the Dummy
Added a shrine to the temple that can boost a character’s weapon attack by 2
  - The character must be able to sacrifice 2 health for this to happen
Added two new healing items
  - Estus Flask: heals 8 health (best of Uncommon loot)
  - Chug Jug: heals 10 health and all status effects (best of Rare loot)
Added a randomize button to the sponsor screen to pick a random sponsor (or not one at all)
Added a game option to change starting health
  - The health can be anything, but healing and weapon values will not scale to match it. So battles may take forever the higher the starting health
??? (Rare event)

Changes

When an opponent is spared in a battle with more than 2 characters, they now flee instead of being left in the battle to possibly attack the one who spared them
When a character heals during battle it now shows the name of the healing item
A character can now loot the healing item of a slain enemy if they have one (and their antidote too!)
When a character’s weapon attack is boosted, the name of the weapon now changes to reflect the number of upgrades it’s had
Lowered the threshold from 8 health to 5 health for healing being the chosen value on the sponsor screen
Made hunger a higher priority on the sponsor screen than weapons
Buffed the values of the previously existing healing items by 1 health to reflect the addition of status effects
Nerfed the damage of the flamethrower and blowgun, but they cause effects now
  - Flamethrower: 4 → 2.5 + Burning Effect
  - Blowgun: 3.5 → 2.5 + Poison Effect
Tracker Jackers now only do 1 damage of attack, but they cause poison now
The winner’s remaining health and their final weapon is shown on the winner’s screen

Fixes

Fixed it to where a healing item will be saved if any of it would be wasted
Fixed an error where a character could get an attack in on 0 health
Fixed it to where the correct form of "a" vs "an" will be used when finding weapons
Fixed Killer Frost temperature
Fixed spelling of sandwich

Focus for next update

Smaller than this current one but bigger than previous ones
Add 2 new Arena Events
Add to existing Arena Events(?) and tidy them up
Add new weapons (including a new Legendary tier of rarity)
Polish weapons a bit
Mild revamp to explosives
Random Stats mode for Realistic
