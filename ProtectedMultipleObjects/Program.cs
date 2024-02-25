using System.Xml.Linq;

namespace PrivateMultipleObjects;
//base class
class Shoes
{
    protected string Name;
    protected string Type;

    //default constuctor
    public Shoes()
    {
        Name = string.Empty;
        Type = string.Empty;
    }
    //parameterized constructor
    public Shoes(string name, string type)
    {
        Name = name;
        Type = type;
    }

    //Get-Set Methods
    //public string getName()
    //{
    //    return Name;
    //}
    //public string getType()
    //{
    //    return Type;
    //}
    //public void setName(string name)
    //{
    //    Name = name;
    //}
    //public void setType(string type)
    //{
    //    Type = type;
    //}
    public virtual void addChange()
    {
        Console.Write("Name: ");
        Name= (Console.ReadLine());
        Console.Write("Type: ");
        Type = (Console.ReadLine());
    }
    public virtual void print()
    {
        Console.WriteLine();
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Type: {Type}");
    }
    class Sneaker : Shoes
    {
        protected string Color;
        protected string Condition;
        protected int Size;

        //default constructor
        public Sneaker()
        //: base()
        {
            Name = string.Empty;
            Type = string.Empty;
            Color = string.Empty;
            Condition = string.Empty;
            Size = 0;
        }
        //parameterized constructor
        public Sneaker(string name, string type, string color, string condition, int size)
            //: base()
        {
            Name = name;
            Type = type;
            Color = color;
            Condition = condition;
            Size = size;
        }
        //get&set methods
        //public void setColor(string color)
        //{
        //    Color = color;
        //}
        //public void setCondition(string condition)
        //{
        //    Condition = condition;
        //}
        //public void setSize(int size)
        //{
        //    Size = size;
        //}
        //public string getColor()
        //{
        //    return Color;
        //}
        //public string getCondition()
        //{
        //    return Condition;
        //}
        //public int getSize()
        //{
        //    return Size;
        //}
        //add-change-display to override base class
        public override void addChange()
        {
            //base.addChange();
            Console.Write("Name: ");
            Name = (Console.ReadLine());
            Console.Write("Type: ");
            Type = (Console.ReadLine());
            Console.Write("Color: ");
            Color=(Console.ReadLine());
            Console.Write("Condition: ");
            Condition=(Console.ReadLine());
            Console.Write("Size: ");
            Size=(int.Parse(Console.ReadLine()));
        }
        public override void print()
        {
            //base.print();
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Condition: {Condition}");
            Console.WriteLine($"Size: {Size}");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("How many shoes would you like to enter?");
            int maxShoes;

            while (!int.TryParse(Console.ReadLine(), out maxShoes))
                Console.WriteLine("Please enter a whole number");

            //array of base class objects & array of derived class
            Shoes[] shoe = new Shoes[maxShoes];
            Console.WriteLine();
            Console.WriteLine("How many sneakers do you want to enter?");
            int maxSneak;
            while (!int.TryParse(Console.ReadLine(), out maxSneak))
                Console.WriteLine("Please enter a whole number");
            //array of sneakers
            Sneaker[] sneak = new Sneaker[maxSneak];

            int choice, rec, type;
            int shoeCounter = 0;
            int sneakCounter = 0;
            choice = Menu();
            while (choice != 4)
            {
                Console.WriteLine();
                Console.WriteLine("Enter 1 for Sneaker or 2 for Shoes");
                while (!int.TryParse(Console.ReadLine(), out type))
                    Console.WriteLine("1 for Sneaker or 2 for Shoes");
                try
                {
                    switch (choice)
                    {
                        case 1: //Add
                            if (type == 1) //Sneaker
                            {
                                if (sneakCounter < maxSneak)
                                {
                                    sneak[sneakCounter] = new Sneaker();
                                    sneak[sneakCounter].addChange();
                                    sneakCounter++;
                                }
                                else
                                    Console.WriteLine("The maximun number of sneakers has been added");
                            }
                            else //Shoes
                            {
                                if (shoeCounter < maxShoes)
                                {
                                    shoe[shoeCounter] = new Shoes();
                                    shoe[shoeCounter].addChange();
                                    shoeCounter++;
                                }
                                else
                                    Console.WriteLine("The maximum number of shoes has been added");
                            }
                            break;
                        case 2: //Change
                            Console.WriteLine("Enter the recorded number you want to change: ");
                            while (!int.TryParse(Console.ReadLine(), out rec))
                                Console.WriteLine("Enter the recorded number you want to change: ");
                            rec--;
                            if (type == 1)//Sneaker
                            {
                                while (rec > sneakCounter - 1 || rec < 0)
                                {
                                    Console.WriteLine("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.WriteLine("Enter the recorded number you want to change: ");
                                    rec--;
                                }
                                sneak[rec].addChange();
                            }
                            else //Shoes
                            {
                                while (rec > shoeCounter - 1 || rec < 0)
                                {
                                    Console.WriteLine("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.WriteLine("Enter the recorded number you want to change: ");
                                    rec--;
                                }
                                shoe[rec].addChange();
                            }
                            break;
                        case 3:
                            if (type == 1)
                            {
                                for (int i = 0; i < sneakCounter; i++)
                                    sneak[i].print();
                            }
                            else
                            {
                                for (int i = 0; i < shoeCounter; i++)
                                    shoe[i].print();
                            }
                            break;
                        default:
                            Console.WriteLine("You made an invalid selection, please try again");
                            break;
                    }
                }

                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                choice = Menu();

            }

        }
        private static int Menu()
        {
            Console.WriteLine();
            Console.WriteLine("Please make a selection from the menu");
            Console.WriteLine("1-Add 2-Change 3-Print 4-Quit");
            int selection = 0;
            while (selection < 1 || selection > 4)
                while (!int.TryParse(Console.ReadLine(), out selection))
                    Console.WriteLine("1-Add 2-Change 3-Print 4-Quit");
            return selection;
        }
    }
}

