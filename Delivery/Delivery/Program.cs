using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Delivery
{
    class Program
    {
        private static string edge = "※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※\n※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※";
        private static string[] store = { "베스킨아이스", "차이나푸드", "신사떡볶이" };
        private static string[] icefood = { "뉴욕 치즈 케이크", "엄마는 외계인", "아몬드 봉봉봉" };
        private static int[] icefoodPrice = { 4000, 4000, 4000 };
        private static string[] chinafood = { "짜장면", "짬뽕", "탕수육" };
        private static int[] chinafoodPrice = { 3000, 6000, 11000 };
        private static string[] hotfood = { "순한맛 떡볶이", " 치즈 떡볶이", "매운 떡볶이" };
        private static int[] hotfoodPrice = { 3000, 4000, 3000 };
        private static string[] foodName;
        private static string[] viewFood;

        static void Start()
        {
            Console.SetWindowSize(80, 40);
            Console.Clear();
            Console.WriteLine(edge);
            for (int i = 0; i < 7; i++) { Console.WriteLine(); }
            Console.WriteLine("                         @        @@@@@@@@@  @@@@@@@@@                                ");
            Console.WriteLine("                        @ @       @       @  @       @                                ");
            Console.WriteLine("                       @   @      @       @  @       @                                ");
            Console.WriteLine("                      @@@@@@@     @@@@@@@@@  @@@@@@@@@                                ");
            Console.WriteLine("                     @       @    @          @                                        ");
            Console.WriteLine("                    @         @   @          @                                        ");
            Console.WriteLine("                   @           @  @          @                                        ");
            for (int i = 0; i < 2; i++) { Console.WriteLine(); }
            Console.WriteLine("                               배달의 행복                                            ");
            for (int i = 0; i < 2; i++) { Console.WriteLine(); }
            Console.WriteLine("                  Enter를 누르면 다음 화면으로 이동합니다.                            ");
            for (int i = 0; i < 10; i++) { Console.WriteLine(); }
            Console.WriteLine(edge);
            ConsoleKeyInfo s = Console.ReadKey();
            switch (s.Key)
            {
                case ConsoleKey.Enter:
                    Home();
                    break;
                default:
                    Console.WriteLine("Enter를 눌러주세요!");
                    break;
            }
        }
        static void Home()
        {
            Console.Clear();
            Console.WriteLine(edge);
            for (int i = 0; i < 7; i++) { Console.WriteLine(); }
            Console.WriteLine("                               배달의                                                  ");
            Console.WriteLine("                                행복                                                   ");
            Console.WriteLine("\n                         무엇을 하시겠습니까?                                        ");
            for (int i = 0; i < 5; i++) { Console.WriteLine(); }
            Console.WriteLine("                            1. 음식 주문                                               ");
            Console.WriteLine("\n                            2. 주문 내역                                             ");
            Console.WriteLine("\n                            3. 나가기                                                ");
            for (int i = 0; i < 7; i++) { Console.WriteLine(); }
            Console.WriteLine(edge + "\n");
            int n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1:
                    Order();
                    break;
                case 2:
                    View(viewFood);
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }
        static void Order()
        {
            Console.Clear();
            Console.WriteLine(edge);
            for (int i = 0; i < 3; i++) { Console.WriteLine(); }
            Console.WriteLine("                                  주문하기                                                 \n");
            string[] totalfood = Concat(icefood, chinafood, hotfood); //랜덤으로 메뉴 추천위해 메뉴 다 합치기
            Random ran = new Random();
            string ranfood = totalfood[ran.Next(0, totalfood.Length)];
            Console.WriteLine("                             *오늘의 랜덤 음식* \n\n");
            Console.WriteLine("                       " + ranfood + "을(를) 추천드립니다!!\n\n\n\n\n");
            Console.WriteLine("                         어떤 곳에 주문하시겠습니까?\n");
            for (int i = 0; i < store.Length; i++) { Console.WriteLine("                               " + (i + 1) + ". " + store[i] + "\n"); }
            for (int i = 0; i < 5; i++) { Console.WriteLine(); }
            Console.WriteLine(edge + "\n");
            int storenum = int.Parse(Console.ReadLine());
            switch (storenum)
            {
                case 1:
                    string storeName = store[0];
                    Reservation(storeName, icefood, icefoodPrice);
                    break;
                case 2:
                    storeName = store[1];
                    Reservation(storeName, chinafood, chinafoodPrice);
                    break;
                case 3:
                    storeName = store[2];
                    Reservation(storeName, hotfood, hotfoodPrice);
                    break;
            }
            static void Reservation(string a, string[] b, int[] c)
            {
                bool confirm = false; //주문 확인용
                while (confirm == false)
                {
                    Console.Clear();
                    Console.WriteLine(edge);
                    for (int i = 0; i < 7; i++) { Console.WriteLine(); }
                    Console.WriteLine("                      " + a + "가게에 오신 것을 환영합니다!                                      \n\n\n");
                    Console.WriteLine("                         몇 개 음식을 주문하시겠습니까?                                        \n\n");
                    for (int i = 0; i < b.Length; i++) { Console.WriteLine("                           " + (i + 1) + ". " + b[i] + "   " + c[i] + "\n"); }
                    int cnt = int.Parse(Console.ReadLine());
                    Console.WriteLine("                         어떤 음식을 주문하시겠습니까?                                        \n\n\n\n");
                    string[] foodName = new string[cnt];
                    string foodInsert;
                    string[] viewFood = new string[cnt];
                    for (int i = 0; i < cnt; i++)
                    {
                        foodInsert = Console.ReadLine();
                        foodName[i] = foodInsert;
                    }
                    Console.WriteLine("\n\n                            주문하신 음식\n");
                    for (int i = 0; i < cnt; i++)
                    {
                        Console.Write("                                 " + foodName[i] + "\n");
                    }
                    Console.WriteLine("\n                    이 맞습니까?(맞으면 1, 아니면 0 입력)\n\n");
                    Console.WriteLine(edge + "\n");
                    int confirmNum = int.Parse(Console.ReadLine());
                    if (confirmNum == 1)
                    {
                        confirm = true;
                        for (int i = 0; i < cnt; i++) //주문한 음식이랑 있는 음식이랑 맞는지
                        {
                            viewFood[i] = foodName[i];
                        }
                        Console.Clear();
                        Console.WriteLine(edge);
                        for (int i = 0; i < 7; i++) { Console.WriteLine(); }
                        Console.WriteLine("                      주문내역을 확인해주시고, 기다려주십시오!          \n\n\n");
                        Console.WriteLine("                                                     ♨♨                   ");
                        Console.WriteLine("                         ┏------------┑┍--------┑┍--------┑                ");
                        Console.WriteLine("                         ┣▣▣▣▣▣▣┝┥▣▣▣▣┝┥▣▣▣▣│                ");
                        Console.WriteLine("                         ┗--●------●┙┕●----●┙┕●----●┙                \n\n\n\n\n");
                        int x = 21;
                        while (x < 45)
                        {
                            Console.SetCursorPosition(x, 21);
                            if (x % 3 == 0)
                            {
                                Console.WriteLine("       ~~배달~~                         ");

                            }
                            else if (x % 3 == 1)
                            {
                                Console.WriteLine("       ~~확인~~                         ");
                            }
                            else
                            {
                                Console.WriteLine("       ~~중~~                         ");
                            }
                            Thread.Sleep(500);
                            x++;
                        }
                        for (int i = 0; i < 5; i++) { Console.WriteLine(); }
                        Console.WriteLine("\n\n                       Enter을 눌러주문 내역을 확인해주세요\n\n");
                        Console.WriteLine(edge);
                        ConsoleKeyInfo s = Console.ReadKey();
                        switch (s.Key)
                        {
                            case ConsoleKey.Enter:
                                View(viewFood);
                                break;
                            default:
                                Console.WriteLine("Enter를 눌러주세요!");
                                break;
                        }
                    }
                    else
                    {
                        confirm = false;
                        continue;
                    }
                }
            }

        }
        static void print(string[] a)
        {
            for (int i = 0; i < a.Length; i++) { Console.WriteLine(a[i] + " "); }
        }
        static string[] Concat(string[] a, string[] b, string[] c)
        {
            string[] totalfood = new string[a.Length + b.Length + c.Length];
            int i;
            for (i = 0; i < a.Length; i++) { totalfood[i] = a[i]; }
            for (i = a.Length; i < a.Length + b.Length; i++) { totalfood[i] = b[i - a.Length]; }
            for (i = a.Length + b.Length; i < a.Length + b.Length + c.Length; i++) { totalfood[i] = c[i - a.Length - b.Length]; }
            return totalfood;
        }
        static void View(string[] a)
        {
            Console.Clear();
            Console.WriteLine(edge);
            for (int i = 0; i < 7; i++) { Console.WriteLine(); }
            if (a == null)
            {
                Console.WriteLine("                    음식을 주문하시고 다시 시도해주십시오!                           ");
                for (int i = 0; i < 25; i++)
                {
                    Console.WriteLine();
                }
                Console.WriteLine(edge);
                ConsoleKeyInfo s = Console.ReadKey();
                switch (s.Key)
                {
                    case ConsoleKey.Enter:
                        Home();
                        break;
                    default:
                        Console.WriteLine("Enter를 눌러주세요!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("                                주문 내역 보기                                         \n\n");
                for (int i = 0; i < a.Length; i++)
                {
                    Console.WriteLine("                                  " + a[i] + "\n");
                }
                for (int i = 0; i < 15; i++) { Console.WriteLine(); }
                Console.WriteLine(edge);
                ConsoleKeyInfo s = Console.ReadKey();
                switch (s.Key)
                {
                    case ConsoleKey.Enter:
                        Home();
                        break;
                    default:
                        Console.WriteLine("Enter를 눌러주세요!");
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            Start();
        }
    }
}