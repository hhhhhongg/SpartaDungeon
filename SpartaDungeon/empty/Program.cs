using System;
using System.Collections.Generic;

// 아이템을 나타내는 구조체
struct Item
{
    public string itemName;
    public int itemID;
    public bool isEquipped; // 아이템이 장착되었는지 여부
}

class Inventory
{
    private List<Item> items;

    public Inventory()
    {
        items = new List<Item>
        {
            new Item { itemName = "Health Potion", itemID = 1, isEquipped = false },
            new Item { itemName = "Sword", itemID = 2, isEquipped = false },
            // 다른 아이템들 추가
        };
    }

    // 아이템 목록 출력
    public void DisplayItems()
    {
        Console.WriteLine("아이템 목록:");

        for (int i = 0; i < items.Count; i++)
        {
            string equippedStatus = items[i].isEquipped ? "E" : ""; // 아이템이 장착되었으면 "E"를 표시
            Console.WriteLine($"{i + 1}. [{equippedStatus}] {items[i].itemName}");
        }
    }

    // 아이템 장착/해제
    public void ToggleEquip(int itemNumber)
    {
        if (itemNumber >= 1 && itemNumber <= items.Count)
        {
            int index = itemNumber - 1;

            if (items[index].isEquipped)
            {
                Console.WriteLine($"{items[index].itemName} 장착 해제");
            }
            else
            {
                Console.WriteLine($"{items[index].itemName} 장착 완료");
            }
        }
        else
        {
            Console.WriteLine("유효하지 않은 아이템 번호입니다.");
        }
    }
}

class Program
{
    static void Main()
    {
        // 인벤토리 생성
        Inventory myInventory = new Inventory();

        // 아이템 목록 출력
        myInventory.DisplayItems();

        // 아이템 장착/해제
        Console.Write("장착할 아이템 번호를 입력하세요: ");
        int itemNumber = Convert.ToInt32(Console.ReadLine());
        myInventory.ToggleEquip(itemNumber);

        // 아이템 목록 다시 출력
        myInventory.DisplayItems();
    }
}
