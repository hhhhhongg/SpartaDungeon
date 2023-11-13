namespace SpartaDungeon
{
    internal class Program
    {
        private static Character player;
        private static Inventory inventory;

        static void Main(string[] args)
        {
            GameDataSetting();
            DisplayGameIntro();
        }

        static void GameDataSetting()
        {
            // 캐릭터 정보 세팅
            player = new Character("Chad", "전사", 1, 10, 5, 100, 1500);

            // 아이템 정보 세팅
            inventory = new Inventory();
            inventory.AddItems("무쇠갑옷", 300, 0, 5, "", "무쇠로 만들어져 튼튼한 갑옷입니다.");
            inventory.AddItems("낡은 검", 400, 2, 0, "", "쉽게 볼 수 있는 낡은 검 입니다.");
        }

        //기본 게임창을 보여줄 메소드
        static void DisplayGameIntro()
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 전전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int input = CheckValidInput(1, 2);
            switch (input)
            {
                case 1:
                    DisplayMyInfo();
                    break;

                case 2:
                    DisplayInventory();
                    break;
            }
        }

        // 내정보를 보여줄 메소드
        static void DisplayMyInfo()
        {
            Console.Clear();

            Console.WriteLine("상태보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv.{player.Level}");
            Console.WriteLine($"{player.Name}({player.Job})");
            Console.WriteLine($"공격력 :{player.Atk}");
            Console.WriteLine($"방어력 : {player.Def}");
            Console.WriteLine($"체력 : {player.Hp}");
            Console.WriteLine($"Gold : {player.Gold} G");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            int input = CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
            }
        }

        // 인벤토리 창을 보여줄 메소드
        static void DisplayInventory()
        {
            Console.Clear();
            

            Console.WriteLine("인벤토리");
            Console.WriteLine("보유중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            inventory.ShowItemInfo();
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine("1. 장착관리");
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int input = CheckValidInput(0, 1);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
                case 1:
                    MyEquipment();
                    break;
            }

        }

        //장착관리 메소드
        static void MyEquipment()
        {
            Console.Clear();
            Console.WriteLine("인벤토리 - 장착 관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            inventory.ShowEquipInfo();
            Console.WriteLine("장착(해제)하실 아이템 번호를 입력해주세요:  ");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int input = CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
            }


        }

        // 숫자를 입력했을때에 관한 메소드
        static int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }

                Console.WriteLine("잘못된 입력입니다.");
            }
        }
    }

    // 캐릭터 정보에 관한 클래스
    public class Character
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int Atk { get; }
        public int Def { get; }
        public int Hp { get; }
        public int Gold { get; }

        public Character(string name, string job, int level, int atk, int def, int hp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
        }
    }

    // 아이템은 여러개 생성될 것이기에 구조체로 만듦.
    public struct Item
    {
        public string iName;
        public int iPrice;
        public int iAtk;
        public int iDef;
        public string iEffect;
        public string iDescription;
        public bool isEquipped;
    }

    // 인벤토리에 관한 것들을 관리하는 클래스
    public class Inventory
    {
        private List<Item> items;

        public Inventory()
        {
            items = new List<Item>();
        }

        public void AddItems(string Name, int Price, int Atk, int Def, string Effect, string Description)
        {
            Item newItem = new Item
            {
                iName = Name,
                iPrice = Price,
                iAtk = Atk,
                iDef = Def,
                iEffect = Effect,
                iDescription = Description

            };
            newItem.isEquipped = false;
            items.Add(newItem);
        }

        //아이템 목록줄 메소드
        public void ShowItemInfo()
        {
            foreach (var item in items)
            {
                Console.WriteLine($"{item.iName}, 가격: {item.iPrice}gold, 공격력: {item.iAtk}, 방어력: {item.iDef}, " +
                                  $"효과: {item.iEffect}, 아이템 설명: {item.iDescription}");
            }
        }

        //장착된 아이템 목록을 보여줄 메소드
        public void ShowEquipInfo()
        {
            string equipValue = "";
         
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].isEquipped == false)
                {
                    equipValue = " ";
                }
                else
                {
                    equipValue = "[E]";
                }
                {
                    Console.WriteLine($"{equipValue}{i + 1}.{items[i].iName}, 가격: {items[i].iPrice}gold, 공격력: {items[i].iAtk}, 방어력: {items[i].iDef}, " +
                                      $"효과: {items[i].iEffect}, 아이템 설명: {items[i].iDescription}");
                }
            }
        }
    }
}