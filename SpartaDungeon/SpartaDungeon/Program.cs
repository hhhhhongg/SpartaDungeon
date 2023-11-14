using System.Security.Cryptography.X509Certificates;

namespace SpartaDungeon
{
    internal class Program
    {
        private static Character player;
        private static Inventory inventory;
        static void Main(string[] args)
        {
            GameDataSetting();
            PrintStartLogo();
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

        static void PrintStartLogo()
        {
            // ASCII ART https://textkool.com/en/ascii-art-generator
            Console.WriteLine("===================================================================");
            Console.WriteLine(" ______     ______   ______     ______     ______   ______    ");
            Console.WriteLine(@"/\  ___\   /\  == \ /\  __ \   /\  == \   /\__  _\ /\  __ \   ");
            Console.WriteLine(@"\ \___  \  \ \  _-/ \ \  __ \  \ \  __<   \/_/\ \/ \ \  __ \  ");
            Console.WriteLine(@" \/\_____\  \ \_\    \ \_\ \_\  \ \_\ \_\    \ \_\  \ \_\ \_\ ");
            Console.WriteLine(@"  \/_____/   \/_/     \/_/\/_/   \/_/ /_/     \/_/   \/_/\/_/ ");
            Console.WriteLine(" _____     __  __     __   __     ______     ______     ______     __   __    ");
            Console.WriteLine(@"/\  __-.  /\ \/\ \   /\  -.\ \   /\  ___\   /\  ___\   /\  __ \   /\  -.\ \  ");
            Console.WriteLine(@"\ \ \/\ \ \ \ \_\ \  \ \ \-.  \  \ \ \__ \  \ \  __\   \ \ \/\ \  \ \ \-.  \  ");
            Console.WriteLine(@" \ \____-  \ \_____\  \ \_\\ \_\  \ \_____\  \ \_____\  \ \_____\  \ \_\\ \_\ ");
            Console.WriteLine(@"  \/____/   \/_____/   \/_/ \/_/   \/_____/   \/_____/   \/_____/   \/_/ \/_/ ");
            Console.WriteLine("===================================================================");
            Console.WriteLine("                        Press AnyKey to start                      ");
            Console.WriteLine("===================================================================");
            Console.ReadKey();

        }

        private static void ShowHighlightedText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static void PrintTextWithHighlights(string s1, string s2, string s3 = "")
        {
            Console.Write(s1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(s2);
            Console.ResetColor();
            Console.WriteLine(s3);
        }

        //기본 게임창을 보여줄 메소드
        static void DisplayGameIntro()
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
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
            int bonusAtk = inventory.getSumBonusAtk();
            int bonusDef = inventory.getSumBonusDef();
            Console.Clear();
            Console.WriteLine("◆상태보기◆");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            PrintTextWithHighlights("Lv.",$"{player.Level}", "");
            Console.WriteLine($"{player.Name}({player.Job})");
            PrintTextWithHighlights("공격력 : ", $"{player.Atk + bonusAtk}", bonusAtk > 0 ? $"  +({bonusAtk})" : "");
            PrintTextWithHighlights("방어력 : ", $"{player.Def + bonusDef}", bonusDef > 0 ? $"  +({bonusDef})" : "");
            PrintTextWithHighlights("체력 : ", $"{player.Hp}", "");
            PrintTextWithHighlights("Gold : ", $"{player.Gold}", "");
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
            

            Console.WriteLine("◆인벤토리◆");
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
            Console.WriteLine("◆인벤토리 - 장착 관리◆");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            inventory.ShowEquipInfo();
            Console.WriteLine("장착(해제)하실 아이템 번호를 입력해주세요  ");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int input = CheckValidInput(0, 2);
            switch (input)
            {
                case 0:
                    DisplayInventory();
                    break;
                default:
                    inventory.ToggleEquip(input);
                    MyEquipment();
                    Console.WriteLine($"장착 상태가 변경되었습니다");
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

        public void AddItems(string Name, int Price, int Atk, int Def, string Effect, string Description, int itemCount = 0)
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
                if (item.iAtk > 0 && item.iDef == 0)
                {
                    Console.WriteLine($"{item.iName}   |   가격 : {item.iPrice}gold   |   공격력 : +{item.iAtk}   |   " +
                                  $"효과 : {item.iEffect}   |    아이템 설명 : {item.iDescription}");
                }
                else if (item.iAtk == 0 && item.iDef > 0)
                {
                    Console.WriteLine($"{item.iName}   |   가격 : {item.iPrice}gold   |   방어력 : +{item.iDef}   |   " +
                                  $"효과 : {item.iEffect}   |    아이템 설명 : {item.iDescription}");
                }
                else
                {
                    Console.WriteLine($"{item.iName}   |   가격 : {item.iPrice}gold   |   공격력 : +{item.iAtk}   |   방어력 : +{item.iDef}   |   " +
                                  $"효과  : {item.iEffect}   |   아이템 설명 : {item.iDescription}");
                }
                
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
                    equipValue = "";
                }
                else
                {
                    equipValue = "[E]";
                }

                if (items[i].iAtk > 0 && items[i].iDef == 0)
                {
                    Console.WriteLine($"{i + 1}. {equipValue}{items[i].iName}   |   가격 : {items[i].iPrice}gold   |   공격력 : +{items[i].iAtk}   |   " +
                                  $"효과 : {items[i].iEffect}   |    아이템 설명 : {items[i].iDescription}");
                }
                else if (items[i].iAtk == 0 && items[i].iDef > 0)
                {
                    Console.WriteLine($"{i + 1}. {equipValue}{items[i].iName}   |   가격 : {items[i].iPrice}gold   |   방어력 : +{items[i].iDef}   |   " +
                                  $"효과 : {items[i].iEffect}   |    아이템 설명 : {items[i].iDescription}");
                }
                else
                {
                    Console.WriteLine($"{i + 1}. {equipValue}{items[i].iName}   |   가격 : {items[i].iPrice}gold   |   공격력 : +{items[i].iAtk}   |   방어력 : +{items[i].iDef}   |   " +
                                  $"효과 : {items[i].iEffect}   |   아이템 설명 : {items[i].iDescription}");
                }

            }
        }

        // 아이템 장착 상태 여부를 체크해줄 메소드 
        public void ToggleEquip(int itemIndex)
        {
            if (itemIndex >=1 && itemIndex <= items.Count)
            {
                Item currentItem = items[itemIndex - 1];
                currentItem.isEquipped = !currentItem.isEquipped;
                items[itemIndex - 1] = currentItem;

                Console.WriteLine($"{items[itemIndex - 1].iName}의 장착 상태가 변경되었습니다.");
            }
            else
            {
                Console.WriteLine("잘못 입력하셨습니다.");
            }
        }

        public int getSumBonusAtk()
        {
            int sum = 0;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].isEquipped)
                {
                    sum += items[i].iAtk;
                }
            }
            return sum;
        }

        public int getSumBonusDef()
        {
            int sum = 0;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].isEquipped)
                {
                    sum += items[i].iDef;
                }
            }
            return sum;
        }
    }
}