<h1>GBF</h1>
<h2>Basic Game</h2>
The Basic Game is a <b>Turn-based battle</b> game, in which the Player and the AI have 10HP.<br>
The Player can choose between three different actions, using the number Keys:
<ul>
    <li>Attack (1): Deals 2 damage to the enemy</li>
    <li>Heal (2): Increases the HP by 2 (max. 10 HP)</li>
    <li>Defend (3): Negate all incomming damage until the next turn</li>
</ul>
After the player has taken their turn, the AI chooses one of two actions:
<ul>
    <li>Attack (65% chance): Deal 2-4 Damage to the player</li>
    <li>Charge (35% chance): Print a message that the enemy is charging energy.
    In the following turn a deadly attack is unleashed that instantly kills the player if they don't defend.
</ul>
The battle continues until either the player's HP or the enemy's reaches zero HP.

<h2>Game Design</h2>
<h3>Issues</h3>
The game is too simple and too repetitive. The player can mostly attacking and healing. If the enemy is charging, then the enemy defends.
Once the game ends, there is no need to continue playing, since the process is the same again.

<h3>Possible improvements</h3>
How would one improve the game to make it more fun??<br>
Since I personally like games in which the <b>stats can be improved</b>. I would implement a possible stats improvement after a fight or wave. 
Having <b>more attack options</b> might also be good. The Player might have to choose between magic damage or physical damage. The List of improvements might look like this.
<ol>
    <li>stats can be improved</li>
    <li>more attack options</li>
    <li>more Levels</li>
    <li>Boss???</li>
    <li>Player is not alone. (controlls 3 player which also gives more attack options)</li>
</ol>

<h3>My Implemntation</h3>
<object data="src/States/StateMachine.pdf" type="application/pdf" width="700px" height="700px">
    <embed src="src/States/StateMachine.pdf">
        <p>This browser does not support PDFs. Please download the PDF to view it: <a href="src/States/StateMachine.pdf">Download PDF</a>.</p>
    </embed>
</object>

I implmented it so, that there is enough room to put more skills into the game or Weapons, etc. Each Player has following stats:
<ol>
    <li>Hp</li>
    <li>Physical ATK</li>
    <li>Magical ATK</li>
    <li>Def (Physical)</li>
    <li>Res (Physical)</li>
    <li>Skill1</li>
    <li>Skill2</li>
</ol>

Each those attributes can be upgraded and the Skills are split into Healing, Tanking and attacking.
No one is forced to pick a route. After Each Stage the player gets Loot (30% chance) and can add the skill into his character.
The Player has 3 character, so he can experiment with setups like: 1 Tank, 1 DamageDealer, 1 Healer or 3 Damage dealer, etc.
This room for freedom is good to keep the game amusing.


