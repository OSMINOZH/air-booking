using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;
using Hello;

namespace abc
{
    interface flight
    {
        public interface View { };
    }
    class User : flight // USER
    {
        public string Name { get; set; }
        public string NameSecond { get; set; }
        public string Email { get; set; }
        public void View()
        {
            Console.WriteLine("Пользователь: " + Name + " " + NameSecond + " (" + Email + ")");
        }
    }
    class AviaCompany : flight // Company
    {
        public string NameCompany { get; set; }
        public int CodeAvia { get; set; }
        public void View()
        {
            Console.WriteLine("Авиакомпания: " + NameCompany);
            Console.WriteLine("Авиакод: " + CodeAvia);
        }
    }
    class StartPoint : flight // Place_to
    {
        public string NameAirport { get; set; }
        public string CodeAirport { get; set; }

        public void View()
        {
            Console.WriteLine("Аэропорт вылета: " + NameAirport);
            Console.WriteLine("Код аэропорта вылета: " + CodeAirport);
        }
    }
    class DestinationPoint : flight // Place_from
    {
        public string NameAirport { get; set; }
        public string CodeAirport { get; set; }

        public void View()
        {
            Console.WriteLine("Аэропорт прилёта: " + NameAirport);
            Console.WriteLine("Код аэропорта прилёта: " + CodeAirport);
        }
    }
    class Flights : flight // Flights // NEED TO RENAME FLIGHTS
    {
        public int IdFlight { get; set; }
        public string TypeAircraft { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeDestination { get; set; }
        public int Price { get; set; }
        public int SitsEmpty { get; set; }
        public string Status { get; set; } // !! Сделать систему определения времени, текущее время рейса прошло или нет

        public void View()
        {
            Console.WriteLine("Номер рейса: " + IdFlight);
            Console.WriteLine("Тип самолёта: " + TypeAircraft);
            Console.WriteLine("Время вылета: " + TimeStart);
            Console.WriteLine("Время прилёта: " + TimeDestination);
            Console.WriteLine("Стоимость билета: " + Price);
            Console.WriteLine("Кол-во пустых мест: " + SitsEmpty);
            Console.WriteLine("Статус рейса:" + Status);
        }
    }
    class Ticket : flight // FLIGHTS
    {
        public int IdTicket { get; set; }
        public int Price { get; set; }
        public int Sit { get; set; }
        public string User { get; set; }
        public void View()
        {
            Console.WriteLine("Номер билета: " + IdTicket);
            Console.WriteLine("Стоимость: " + Price);
            Console.WriteLine("Сиденье: " + Sit);
            Console.WriteLine("Пользователь: " + User);
        }

    }
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            NLog.Common.InternalLogger.LogLevel = NLog.LogLevel.Debug;
            NLog.Common.InternalLogger.LogToConsole = true;
            NLog.Common.InternalLogger.LogFile = @"c:\temp\nlog-internal.txt";

            var hv = new Hello();
            hv.Massage();

            int kolvo_flight, i, check_found = 0, check_idFlight, mode = 0, search_mode = 0;
            string check_name, check_nameSecond, check_startPoint, check_destinationPoint;
            Console.Write("Введите количество рейсов: ");
            kolvo_flight = Int32.Parse(Console.ReadLine());
            Flights[] flights = new Flights[kolvo_flight];
            User[] user = new User[kolvo_flight];
            AviaCompany[] aviacompany = new AviaCompany[kolvo_flight];
            StartPoint[] startpoint = new StartPoint[kolvo_flight];
            DestinationPoint[] destinationpoint = new DestinationPoint[kolvo_flight];
            Ticket[] ticket = new Ticket[kolvo_flight];
            for (i = 0; i < kolvo_flight; i++)
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("ЗАПОЛНИТЕ ИНФОРМАЦИЮ О РЕЙСЕ:");
                    logger.Info("test test test.");
                    // INITIALIZATION
                    user[i] = new User();
                    flights[i] = new Flights();
                    aviacompany[i] = new AviaCompany();
                    startpoint[i] = new StartPoint();
                    destinationpoint[i] = new DestinationPoint();
                    ticket[i] = new Ticket();
                    // Flights
                    Console.Write("Номер рейса: ");
                    flights[i].IdFlight = Int32.Parse(Console.ReadLine()); //Int32.Parse(Console.ReadLine());
                    Console.Write("Тип самолёта: ");
                    flights[i].TypeAircraft = Console.ReadLine();
                    Console.WriteLine("Время вылета: [01/01/2001 01:01]");  // Время поменять в классе тип // Сделать метод определения числа
                    logger.Trace("logger.Trace");
                    logger.Debug("logger.Debug");
                    flights[i].TimeStart = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", null);
                    Console.WriteLine("Время прилёта: [01/01/2001 01:01]"); // Время поменять в классе тип
                    logger.Info("test test test.");
                    flights[i].TimeDestination = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", null);
                    Console.Write("Стоимость билета: ");
                    flights[i].Price = Int32.Parse(Console.ReadLine()); //Int32.Parse(Console.ReadLine());
                    Console.Write("Оставшиеся места: ");
                    flights[i].SitsEmpty = Int32.Parse(Console.ReadLine()); //Int32.Parse(Console.ReadLine());
                    // AVIA COMPANY
                    Console.Write("Название Авиакомпании: ");
                    aviacompany[i].NameCompany = Console.ReadLine();
                    Console.Write("Авиакод: ");
                    aviacompany[i].CodeAvia = Int32.Parse(Console.ReadLine());
                    // START POINT
                    Console.Write("Название Аэропорта вылета: ");
                    startpoint[i].NameAirport = Console.ReadLine();
                    Console.Write("Код Аэропорта вылета: ");
                    startpoint[i].CodeAirport = Console.ReadLine();
                    // DESTINATION POINT
                    Console.Write("Название Аэропорта прилёта: ");
                    destinationpoint[i].NameAirport = Console.ReadLine();
                    Console.Write("Код Аэропорта прилёта: ");
                    destinationpoint[i].CodeAirport = Console.ReadLine();
                    Console.WriteLine();
                    logger.Warn("logger.Warn");
                    logger.Error("logger.Error");
                    logger.Fatal("logger.Fatal");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("ex: " + ex);
                    logger.Info("logger.Info");
                    logger.Warn("logger.Warn");
                    logger.Error("logger.Error");
                    logger.Fatal("logger.Fatal");

                }
            }
            Console.WriteLine("--------------------------------------");
            ConsoleKeyInfo esc;
            do // LOOP
            {
                for (i = 0; i < kolvo_flight; i++) // CHECK FOR AVAILABLE FLIGHTS
                {
                    if (flights[i].TimeStart > DateTime.UtcNow)
                    {
                        flights[i].Status = "Ожидание";
                    }
                    else if (flights[i].TimeStart == DateTime.UtcNow)
                    {
                        flights[i].Status = "Вылетел";
                    }
                    else if (flights[i].TimeDestination < DateTime.UtcNow)
                    {
                        flights[i].Status = "Прибыл";
                    }
                }
                Console.WriteLine();
                Console.WriteLine($"Выберите режим: \n [1] ПОИСК РЕЙСОВ [2] ПОКУПКА БИЛЕТОВ [3] ДОБАВЛЕНИЕ РЕЙСОВ\n");
                logger.Info("logger.Info");
                logger.Warn("logger.Warn");
                logger.Error("logger.Error");
                logger.Fatal("logger.Fatal");
                Console.Write("Режим: ");
                mode = Int32.Parse(Console.ReadLine());
                if (mode <= 0 || mode > 3) { }
                else if (mode == 1)
                {
                    Console.WriteLine($"Выберите режим поиска: \n [1] ПОИСК ПО ПУНКТУ ОТПРАВЛЕНИЯ И НАЗНАЧЕНИЯ [2] ПОИСК ПО НОМЕРУ РЕЙСА \n [0] ВЕРНУТЬСЯ НАЗАД");
                    logger.Info("logger.Info");
                    logger.Warn("logger.Warn");
                    logger.Error("logger.Error");
                    logger.Fatal("logger.Fatal");
                    Console.Write("Режим поиска: ");
                    search_mode = Int32.Parse(Console.ReadLine());
                    switch (search_mode)
                    {
                        case 0:
                            Console.WriteLine("Выберите режим поиска!");
                            logger.Info("logger.Info");
                            logger.Warn("logger.Warn");
                            logger.Error("logger.Error");
                            logger.Fatal("logger.Fatal");
                            break;
                        case 1:
                            Console.Write("Введите пункт вылета: ");
                            check_startPoint = Console.ReadLine();
                            Console.Write("Введите пункт прилёта: ");
                            check_destinationPoint = Console.ReadLine();
                            for (i = 0; i < kolvo_flight; i++)
                            {
                                if ((check_startPoint == startpoint[i].NameAirport || check_startPoint == startpoint[i].CodeAirport)
                                    && (check_destinationPoint == destinationpoint[i].NameAirport || check_destinationPoint == destinationpoint[i].CodeAirport)) // Сделать проверку на INT
                                {
                                    check_found = 1;
                                    Console.WriteLine();
                                    Console.WriteLine("НАЙДЕНЫЕ РЕЙСЫ: ");
                                    logger.Info("test test test.");
                                    startpoint[i].View();
                                    destinationpoint[i].View();
                                    flights[i].View(); check_found = 1;
                                }
                            }
                            if (check_found == 0)
                            {
                                Console.WriteLine("НЕ НАЙДЕНЫ ПУНКТЫ ВЫЛЕТА/ПРИЛЁТА  " + check_startPoint + " " + check_destinationPoint);
                                logger.Info("test test test.");
                            }
                            break;
                        case 2:
                            Console.Write("Введите номер рейса: ");
                            check_idFlight = Int32.Parse(Console.ReadLine());
                            for (i = 0; i < kolvo_flight; i++)
                            {
                                if (check_idFlight == flights[i].IdFlight)
                                {
                                    check_found = 1;
                                    Console.WriteLine();
                                    Console.WriteLine("НАЙДЕНЫЕ РЕЙСЫ: ");
                                    logger.Info("test test test.");
                                    flights[i].View(); check_found = 1;
                                }
                            }
                            if (check_found == 0)
                            {
                                Console.WriteLine("НЕ НАЙДЕНЫ РЕЙСЫ  " + check_idFlight);
                            }
                            break;
                    }
                }
                else if (mode == 2) // BUY TICKET
                {
                    Console.Write("Введите номер рейса: ");
                    check_idFlight = Int32.Parse(Console.ReadLine());
                    for (i = 0; i < kolvo_flight; i++)
                    {
                        if ((check_idFlight == flights[i].IdFlight) && (flights[i].SitsEmpty != 0) && (flights[i].Status == "Ожидание"))
                        {
                            check_found = 1;
                            Console.WriteLine();
                            Console.WriteLine("НАЙДЕНЫЕ РЕЙСЫ: ");
                            logger.Info("test test test.");
                            flights[i].View(); check_found = 1;
                            Console.WriteLine("Хотите купить билет? Y/N");
                            string to_buy = Console.ReadLine(); // STRING
                            if (to_buy.ToString() == "Y" || to_buy == "y")
                            {
                                // USER
                                Console.Write("Имя пользователя: ");
                                user[i].Name = Console.ReadLine();
                                Console.Write("Фамилия пользователя: ");
                                user[i].NameSecond = Console.ReadLine();
                                Console.Write("Email пользователя: ");
                                user[i].Email = Console.ReadLine();
                                // TICKET
                                int empty_sits_temp = flights[i].SitsEmpty;
                                string temp = $"{flights[i].IdFlight}{flights[i].SitsEmpty}{flights[i].Price}{flights[i].IdFlight}"; // IDFLIGHT + SIT + PRICE + IDFLIGHT
                                ticket[i].Sit = empty_sits_temp;
                                ticket[i].Price = flights[i].Price;
                                flights[i].SitsEmpty = empty_sits_temp - 1; // MINUS SIT
                                ticket[i].IdTicket = Convert.ToInt32(temp);
                                ticket[i].User = $"{user[i].Name}_{user[i].NameSecond}_{user[i].Email}";
                                Console.WriteLine("\n \n \n Поздравляем с приобретением билета! \n \n ВАШ БИЛЕТ:");
                                ticket[i].View();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Рейс недоступен или отсутствует");
                            logger.Info("test test test.");
                        }
                    }
                    if (check_found == 0)
                    {
                        Console.WriteLine("НЕ НАЙДЕНЫ РЕЙСЫ  " + check_idFlight);
                        logger.Info("test test test.");
                    }
                }
                else if (mode == 3) // ADD NEW FLIGHTS
                {
                    Console.Write("Введите количество рейсов: ");
                    kolvo_flight += Int32.Parse(Console.ReadLine());
                    for (i = 0; i < kolvo_flight; i++)
                    {
                        try
                        {
                            Console.WriteLine();
                            Console.WriteLine("ЗАПОЛНИТЕ ИНФОРМАЦИЮ О РЕЙСЕ:");
                            logger.Info("test test test.");
                            logger.Fatal("This is a fatal message");
                            logger.Trace("logger.Trace");
                            logger.Debug("logger.Debug");
                            // INITIALIZATION
                            user[i] = new User();
                            flights[i] = new Flights();
                            aviacompany[i] = new AviaCompany();
                            startpoint[i] = new StartPoint();
                            destinationpoint[i] = new DestinationPoint();
                            ticket[i] = new Ticket();
                            // USER
                            // Flights
                            Console.Write("Номер рейса: ");
                            flights[i].IdFlight = Int32.Parse(Console.ReadLine()); //Int32.Parse(Console.ReadLine());
                            Console.Write("Тип самолёта: ");
                            flights[i].TypeAircraft = Console.ReadLine();
                            Console.WriteLine("Время вылета: [01/01/2001 01:01]");  // Время поменять в классе тип // Сделать метод определения числа
                            flights[i].TimeStart = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", null);
                            Console.WriteLine("Время прилёта: [01/01/2001 01:01]"); // Время поменять в классе тип
                            flights[i].TimeDestination = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", null);
                            Console.Write("Стоимость билета: ");
                            flights[i].Price = Int32.Parse(Console.ReadLine()); //Int32.Parse(Console.ReadLine());
                            Console.Write("Оставшиеся места: ");
                            flights[i].SitsEmpty = Int32.Parse(Console.ReadLine()); //Int32.Parse(Console.ReadLine());
                            // AVIA COMPANY
                            Console.Write("Название Авиакомпании: ");
                            aviacompany[i].NameCompany = Console.ReadLine();
                            Console.Write("Авиакод: ");
                            aviacompany[i].CodeAvia = Int32.Parse(Console.ReadLine());
                            // START POINT
                            Console.Write("Название Аэропорта вылета: ");
                            startpoint[i].NameAirport = Console.ReadLine();
                            Console.Write("Код Аэропорта вылета: ");
                            startpoint[i].CodeAirport = Console.ReadLine();
                            // DESTINATION POINT
                            Console.Write("Название Аэропорта прилёта: ");
                            destinationpoint[i].NameAirport = Console.ReadLine();
                            Console.Write("Код Аэропорта прилёта: ");
                            destinationpoint[i].CodeAirport = Console.ReadLine();
                            Console.WriteLine();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("ex: " + ex);
                            logger.Info("test test test.");  
                        }
                    }
                }
                Console.WriteLine("ЧТОБЫ ВЫЙТИ НАЖМИТЕ КНОПКУ 'ESC' || ЧТОБЫ ОСТАТЬСЯ НАЖМИТЕ ЛЮБУЮ ДРУГУЮ КНОПКУ");
                logger.Info("test test test.");
                esc = Console.ReadKey();
            } while (esc.Key != ConsoleKey.Escape);
            LogManager.Shutdown();
        }
    }
}
