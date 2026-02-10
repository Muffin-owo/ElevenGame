<p class="has-line-data" data-line-start="0" data-line-end="1">‘Elevens’ is a single-player solitaire card game in which the player aims to remove pairs or triples of cards to reach a final winning state by exhausting the deck. The game is played using a standard 52-card deck.</p>
<p class="has-line-data" data-line-start="3" data-line-end="12">Functional Needs:<br>
The player must be able to start a new game<br>
The game must use a standard 52 card deck with rank A , 2 ,3 , 4 ,5 ,6 ,7 ,8 ,9 , 10 , J , Q and K , and suits clubs , diamonds , hearts , and spades/<br>
The player must deal cards according to rules<br>
The player be able to select cards from the table<br>
The system must detect valid pairs<br>
The system must detect valid triples<br>
The game should detect illegal move<br>
The game should detect win or loss</p>
<p class="has-line-data" data-line-start="14" data-line-end="15">How to Play</p>
<p class="has-line-data" data-line-start="16" data-line-end="24">Run the program.<br>
The table will display cards labeled with indexes 0–8.<br>
Enter:<br>
Two indexes for a pair summing to 11<br>
3 6<br>
Three indexes for a JQK set<br>
2 4 8<br>
Type q or Q to quit the game.</p>
<p class="has-line-data" data-line-start="26" data-line-end="27">Progress already finish card , deck , gamecontroller , table class</p>
<p class="has-line-data" data-line-start="28" data-line-end="35">Cards<br>
int: value<br>
string: suit<br>
-getValue()<br>
-return value<br>
-ToString() : string<br>
- return {suit} of {value}</p>
<p class="has-line-data" data-line-start="36" data-line-end="41">Deck<br>
-shuffle():void<br>
-deal():Deck<br>
-isEmpty():bool<br>
-size():int</p>
<p class="has-line-data" data-line-start="42" data-line-end="47">GameController<br>
-run():void<br>
-submitSelection(string):void<br>
-validateSelection(List&lt;int&gt;):bool<br>
-checkEndState():void</p>
<p class="has-line-data" data-line-start="48" data-line-end="56">Table<br>
-visibleCards():void<br>
-getCard(int):Card<br>
-return cardsOnTable<br>
-isValidIndex(int):bool<br>
-removeCards(List&lt;int&gt;):void<br>
-replaceCards(Deck):void<br>
-isEmpty():bool</p>
