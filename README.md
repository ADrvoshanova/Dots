Dots game
1. Опис на апликацијата
Апликацијата којашто нашиот тим ја имплементира е веќе постоечката игра Dots. 

Link до играта:  http://weplaydots.com/

Целта на играта е да се освојат што повеќе поени, кои се добиваат со поврзување на соседните топчиња коишто се во иста боја. Нашата имплементација содржи два начини на играње и тоа: Timed, на кој играчот има 60 секунди, и Moves на кој играчот има  вкупно 30 потези.

1.1.  Упатство за користење
	На почетокот на играта се отвора главното мени на коешто корисникот има 4 опции и тоа: New Game, High Scores, Аbout и Exit.  Со опцијата New Game корисникот може да  започне нова игра и да направи избор на тип на играта (Timed или Moves).  High Scores ни овозможува увид во листата на играчи со најмногу освоени поени. Во About има некои интересни факти за играта. Exit опцијата ни овозможува терминирање на апликацијата.

1.2. Правила на играта
	При започнување на играта можеме да забележиме матрица со димензии 6x6 која е исполнета со топчиња со различни бои, кои се генерираат на случаен начин. 	Поврзувањето на топчињата се прави со тоа што се црта испрекршена линија од почетното до крајното топче. За да се започне со цртање на линијата играчот треба  покажувачот да го однесе над посакуваното топче и да притисне на левиот клик, со што почнува цртањето на линијата. Одредувањето на патот на линијата се одвива со тоа што играчот го носи покажувачот над топчињата, без притоа да го ослободи левиот клик. По селектирањето на последната точка од патот играчот го ослободува кликот со што завршува исцртувањето на линијата.
	Играчот може да поврзе само соседни топчиња со иста боја по вертикала и хоризонтала и при тоа не може да враќа потег. Линијата за да се исцрта мора да содржи барем две топчиња.
	По успешното исцртување на линијата, поврзаните топчиња се уништуваат, а на нивно место паѓаат топчињата што се над нив. Во најгорните позиции на празните места, кои се ослободени од поместувањето, се генерираат нови топчиња, кои исто така се со случајно избрана боја.
Крајот на играта се постигнува на два начини, во зависност од типот на играта. Играта од тип Moves завршува по искористувањето на сите потези, а Timed завршува по истекувањето на зададеното време. 
Бодувањето на потезите се одвива на следниов начин: (број на селектирани топчиња -2)*2+2. Доколку бројот на селектирани топчиња е поголем од 8, се додаваат дополнителни 10 поени.

2. Опис на имплементацијата
	Играта е имплементирана со помош на Windows Forms Application платформата и C# програмскиот јазик. Апликацијата содржи три форми MainForm, Form1 и HighScoresForm. 
	Првата форма MainForm се користи за навигација низ менијата со помош на повеќе панели. Формата Form1 ја содржи играта, а во формата HighScoresForm се запишани најдобрите 5 играчи со нивните кориснички имиња и број на поени. 
	Класите коишто се користат се: Dot (чува податоци за репрезентација на една точка), Line (чува податоци за една линија), LinesDoc (во неа имаме листа од Line која ги чува моментално формираните линии), Matrix (во оваа класа имаме матрица, dots, со димензии 6x6 во која се чуваат  точките и уште една матрица, filled, за да знаеме дали на одредена позиција во моментот има точка), Scene (во неа чуваме објект од класата Matrix и содржи неколку методи кои служат за бришење на топчињата, враќаат број на селектирани топчиња, го пресметуваат бројот на поени  и имаме метод за одново вчитување на матрицата доколку веќе не постојат никакви валидни потези), Player (содржи Username и Score за еден играч и е серијализабилна).

3. Oпис на класата Dot
	Во класата Dot се чуваат следниве атрибути:
 private string[] colors = { "#FF3DA59E", "#FFE36166", "#FFE9871D", "#FF6CAF60", "#E6DB22", "#9C5DB5" };
        private Color color;
        private static readonly int RADIUS = 10;
        private Brush brush;
        private float x;
        private float y;
        public bool Visited { get; set; }
        public bool Filled { get; set; }	
	Методи кои се имплементирани во класата се: get методи за координатите x и y, get метода за бојата color, конструктор кој прима параметар Random rnd и во него се избира random боја од претходно дефинираните colors, инстанцираме SolidBrush од веќе избраната боја и на visited атрибутот му задаваме вредност false. Други методи кои се имплементирани се: Draw(Graphics g, int x, int y) каде x и y се координатите и цртањето се прави со FillElipse, Move() кој служи за поместување на точката за едно место вертикално надолу во матрицата и IsHit(float x, float y) кој проверува дали покажувачот се наоѓа над точката со дадените координати х и у.

4. Screenshots од изгледот на апликацијата и кратко упатство за користење


Main Menu – корисникот има можност за избор од 4 опции и тоа: New Game, High Scores, Аbout и Exit
	





Ако корисникот избере опцијата New Game ќе се појави овој поглед во којшто мора да внесе Username и потоа за да започне со игра мора го кликне копчето Play.





По кликање на копчето Play се појавува овој поглед во кој му се овозможува на корисникот да одбере каков тип на игра сака да игра, Timed или Moves.





 
По избор на тип на играта се прикажуваат следниве погледи во зависност од изборот, соодветно.
Со кликање на Quit Game, се враќаме на Main Menu, а по завршувањето на играта се прикажува погледот со најдобрите резултати.


До овој поглед, корисникот може да пристапи и со кликнување на копчето High Scores од Main Menu.






До овој поглед, корисникот може да пристапи и со кликнување на копчето About од Main Menu. Во овој поглед има неколку интересни факти за играта Dots. Копчето Main Menu го враќа корисникот на глвниот поглед.







Со избор на опцијата Exit, се прикажува MessageBox од којашто корисникот може да избере дали ќе ја прекине апликацијата или ќе си остане на главниот поглед.
