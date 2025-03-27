OOP lietojums
- Mantošana
	- Tiek lietota bāzes klase Character, kuru manto Player un Enemy klases.
	- Character klasē ir loģika, kas seko līdzi tēla veselībai, uzbrukumiem un saņemtajam damage.
	- Enemy un Player klases manto to loģiku no Character, bet arī tiek pievienotas ekstra lietas, kā aggression.
	- Klases Goblin, Wizard (ietver random magical healing kopā ar Enemy klases loģiku) un Berserker manto no Enemy klases.

- Enkapsulāciju
	- Health setteris tiek lietots Character klasē. Tur es nodrošināju, ka veselība nevar sasniegt mazāk par 0. Ja tā sasniedz 0, tad tiek izsaukta Die() metode.
	- health getteris iegūst veselību, bet nevar tieši piekļūt health laukam ārpus klases.

- Polimorfisms
	- GetHit metode Character klasē ir pārslogota metode, kas var pieņemt int damage vai Weapon weapon argumentius.
	- Overriding ir Attack metodē Berserker un Character klasēs. Berserker override pievieno aggression viņa attacks.

- Abstrakcija
	- Weapon satur abstract void ApplyEffect(Character target), kura tiek īstenota BasicWeapon un PoisonDagger klasē ar override void.

Ko es pievienoju
- Pievienoju assets, ko pati zīmeju (enemies, player izskats, ņemot vērā, kuru weapon izvēlās spēlētājs, background).
- Weapon izvēle ar drop down menu, kas arī nomaina player izskatu. Weapon izvēle ir no sword, poison dagger, bow un club.
- Poison Dagger, kas pievieno Poisoned status effect (arī parādās UI, ja enemy tiek saindēts). Tam ir tikai 30% iespēja, lai notiktu. Tas dara 3 damage 2 rounds pēc kārtas.
- Wizard enemy, kuram ir 30% iespēja, ka viņš dabūs atpakaļ mazliet health (no 8-15).
- Death screen (player sasniedz 0 health), victory screen (visi enemies ir sasnieguši 0 health), pause screen (spiežot Esc pogu).
- Berserker enemy, kurš paliek stiprāks.
- Basic goblin enemy.
