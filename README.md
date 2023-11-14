# SpartaDungeon
C# mission 첫번째 개인과제
---
# 프로젝트 소개
던전을 떠나기전에 마을에서 장비를 구하는 게임을 텍스트로 구현하였습니다.
---
# 필수 요구사항
1. 게임 시작화면
2. 현재 내 상태보기
3. 인벤토리
4. 장착 관리
   이 네가지를 구현하는 것입니다.

# 코드

게임 시작화면과 현재 내상태보기는
주어진 코드를 이용해서 작성하였고
인벤토리 부분과 장착 관리 부분을 직접 작성하였습니다.

우선 아이템은 구조체로 틀을 만들어주었습니다.

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

# <인벤토리 와 장착 관리 부분 코드>

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

우선 인벤토리 클래스를 만들어 준 뒤에 전에 만들어둔 구조체 item형으로 List를 만들어
생성자를 통해 객체를 할당해줍니다.
그리고 AddItems함수로 아이템을 추가할 수 있도록 해주고 기본 장착상태는 false로 만들어줍니다.

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

아이템 목록을 출력해줄 메소드이며 만약에 장착상태가 true 라면 장비 이름앞에 [E]가 들어갈 수 있도록 해줍니다.

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
    }

입력된 숫자를 받아와 아이템 인덱스로 활용해서 아이템의 장착상태를 변경해주는 메소드입니다.
    
