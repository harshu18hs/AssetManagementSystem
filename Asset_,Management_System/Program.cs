using System;
using System.Collections.Generic;
using Asset__Management_System;
namespace Asset_Management_System
{ 
    public class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();
            List<Hardware> hardwares = new List<Hardware>();
            List<Software> softwares = new List<Software>();

            int noBooks = 0, noHardwares = 0, noSoftwares = 0;
        Start:
            Menu menu = new Menu();
            int Cases = int.Parse(Console.ReadLine());
            switch (Cases)
            {
                case 1:
                    Console.WriteLine("No Of Books = {0}", noBooks);
                    int x, y, z;
                    showBook();
                    showHardware();
                    showSoftware();

                    void showBook()
                    {                        Console.Write("\n\t All Available Books are : \n");

                        if (noBooks == 0)
                        {
                        Console.WriteLine(" NO DATA RELATED TO BOOKS AVAILABLE IN LIST ");
                        }
                        if (noBooks > 0)
                        {
                            for (x = 0; x < noBooks; x++)
                            {
                                Console.WriteLine("Serial = {1}, Title = {2},  Author = {3},  DOP = {4}", x + 1, books[x].serial_no, books[x].book_name, books[x].book_author, books[x].book_dop);
                            }
                        }
                    }
                    void showHardware()
                    {
                        Console.Write("\n\t All Available Hardwares are : \n");
                        if (noHardwares == 0)
                        {
                            Console.WriteLine(" NO DATA RELATED TO HARDWARES AVAILABLE IN LIST ");
                        }
                        if (noHardwares > 0)
                        {
                            for (y = 0; y < noHardwares; y++)
                            {
                                Console.WriteLine("Serial = {1}, Type = {2},  Price = {3},  Qty = {4}", y + 1, hardwares[y].serial_no, hardwares[y].hardware_type, hardwares[y].hardware_price, hardwares[y].hardware_qty);
                            }
                       }
                    }
                    void showSoftware()
                    {
                        Console.Write("\n\t All Available Softwares are : \n");

                        if (noSoftwares == 0)
                        {
                            Console.WriteLine(" NO DATA RELATED TO SOFTWARES AVAILABLE IN LIST ");
                        }
                        if (noSoftwares > 0)
                        {
                            for (z = 0; z < noSoftwares; z++)
                            {
                                Console.WriteLine("Serial = {1}, Name = {2},  Licence No = {3},  Licence Description = {4}", z + 1, softwares[z].serial_no, softwares[z].software_name, softwares[z].license_no, softwares[z].license_desc);
                            }
                        }
                    }
                    Console.WriteLine("----------------------------------------------------------------------");
                    break;
                case 2:
                    Console.WriteLine();
                    Console.WriteLine("Add An Asset :- ");
                    Console.WriteLine();
                    Console.Write("Pls Select B - Books,S - Software,H - Hardware : ");
                    Char AssetType = Char.Parse(Console.ReadLine());
                    switch (AssetType)
                    {
                        case ('B' or 'b'):
                            int i, j, n = 1, k = 1;
                            string v_book_name, v_book_author, v_book_dop;
                            int v_serial_no;

                            Console.WriteLine("Selected Book");
                            Console.WriteLine();
                            Console.Write("How many Book Details you want to enter : ");
                            noBooks = int.Parse(Console.ReadLine());
                            Console.Write("\n\nInsert the information of Books :\n");
                            Console.Write("-----------------------------------------\n");
                            for (j = 0; j < noBooks; j++)
                            {
                                Console.WriteLine("Information of Book {0} : ", k);
                                Console.WriteLine();

                                v_serial_no = k;

                                Console.Write("Enter Name of the Book : ");
                                v_book_name = Console.ReadLine();
                                Console.Write("Enter Name of the Author : ");
                                v_book_author = Console.ReadLine();
                                Console.Write("Enter Date Of Publication Book : ");
                                v_book_dop = Console.ReadLine();

                                books.Add(new Book(v_serial_no, v_book_name, v_book_author, v_book_dop));
                                k++;
                                Console.WriteLine();
                            }
                            Console.WriteLine("No Of Books : {0}", noBooks);
                            for (i = 0; i < noBooks; i++)
                            {
                                Console.WriteLine("Serial = {1}, Title = {2},  Author = {3},  DOP = {4}", i + 1, books[i].serial_no, books[i].book_name, books[i].book_author, books[i].book_dop);
                            }
                            break;
                        case ('H' or 'h'):
                            string v_hardware_type;
                            double v_hardware_price;
                            int v_h_serial_no, v_hardware_qty;

                            Console.WriteLine("Selected Hardware");
                            Console.WriteLine();
                            Console.Write("How many Hardware Details you want to enter : ");
                            noHardwares = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            Console.Write("\n\nInsert the information of Hardwares :\n");
                            Console.Write("-----------------------------------------\n");
                            k = 1;
                            for (j = 0; j < noHardwares; j++)
                            {
                                Console.WriteLine("Information of Hardware {0} : ", k);
                                v_h_serial_no = k;
                                Console.Write("Enter Hardware Type : ");
                                v_hardware_type = Console.ReadLine();
                                Console.Write("Enter Hardware Price : ");
                                v_hardware_price = Convert.ToDouble(Console.ReadLine());
                                Console.Write("Enter Hardware Quantity : ");
                                v_hardware_qty = Convert.ToInt32(Console.ReadLine());

                                hardwares.Add(new Hardware(v_h_serial_no, v_hardware_type, v_hardware_price, v_hardware_qty));
                                k++;
                                Console.WriteLine();
                            }
                            for (i = 0; i < noHardwares; i++)
                            {
                                Console.WriteLine("Serial = {1}, Type = {2},  Price = {3},  Qty = {4}", i + 1, hardwares[i].serial_no, hardwares[i].hardware_type, hardwares[i].hardware_price, hardwares[i].hardware_qty);
                            }
                            break;
                        case ('S' or 's'):
                            string v_software_name, v_license_no, v_license_desc;
                            int v_s_serial_no;

                            Console.WriteLine("Selected Software");
                            Console.WriteLine();
                            Console.Write("How many Software Details you want to enter : ");
                            noSoftwares = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            Console.Write("\n\nInsert the information of Softwares :\n");
                            Console.Write("-----------------------------------------\n");
                            k = 1;
                            for (j = 0; j < noSoftwares; j++)
                            {
                                Console.WriteLine("Information of Software {0} : ", k);
                                v_s_serial_no = k;
                                Console.Write("Enter Software Name : ");
                                v_software_name = Console.ReadLine();
                                Console.Write("Enter Licence No : ");
                                v_license_no = Console.ReadLine();
                                Console.Write("Enter Licence Description : ");
                                v_license_desc = Console.ReadLine();

                                softwares.Add(new Software(v_s_serial_no, v_software_name, v_license_no, v_license_desc));
                                k++;
                                Console.WriteLine();
                            }
                            for (i = 0; i < noSoftwares; i++)
                            {
                                Console.WriteLine("Serial = {1}, Name = {2},  Licence No = {3},  Licence Description = {4}", i + 1, softwares[i].serial_no, softwares[i].software_name, softwares[i].license_no, softwares[i].license_desc);
                            }
                            break;
                    }
                    Console.WriteLine("-------------------------------------------------------------------------");
                    break;
                case 3:
                    Console.WriteLine();
                    Console.WriteLine("Search an Asset :- ");
                    Console.WriteLine();
                    Console.Write("Pls Select B - Books,S - Software,H - Hardware : ");
                    Char SearchAssetType = Char.Parse(Console.ReadLine());
                    switch (SearchAssetType)
                    {
                        case ('B' or 'b'):
                            {
                                string v_search_book_name;
                                int n;

                                Console.WriteLine("Selected to Search For Book :- ");
                                Console.WriteLine();
                                Console.Write("Enter the Name of Book To Search : ");
                                v_search_book_name = Console.ReadLine();

                                List<string> bookname = new List<string>();

                                for (n = 0; n < noBooks; n++)
                                {
                                    bookname.Add(books[n].book_name);
                                    Console.WriteLine();
                                }
                                if (bookname.Contains(v_search_book_name))
                                {
                                    Console.Write("There is a Book with Name : ");
                                    Console.WriteLine(v_search_book_name);
                                }
                                else
                                {
                                    Console.Write("No Details of the Book Exist with Name : ");
                                    Console.WriteLine(v_search_book_name);
                                }
                                break;
                            }
                        case ('H' or 'h'):
                            {
                                string v_search_hardware_type;
                                int n;

                                Console.WriteLine("Selected to Search For Hardware Type :- ");
                                Console.WriteLine();
                                Console.Write("Enter the Type of Hardware To Search : ");
                                v_search_hardware_type = Console.ReadLine();

                                List<string> hardware_type = new List<string>();

                                for (n = 0; n < noHardwares; n++)
                                {
                                    hardware_type.Add(hardwares[n].hardware_type);
                                    Console.WriteLine();
                                }
                                if (hardware_type.Contains(v_search_hardware_type))
                                {
                                    Console.Write("There is a Hardware of the Type : ");
                                    Console.WriteLine(v_search_hardware_type);
                                }
                                else
                                {
                                    Console.Write("No Details of the Hardware Exist with Type : ");
                                    Console.WriteLine(v_search_hardware_type);
                                }
                                break;
                            }
                        case ('S' or 's'):
                            {
                                string v_search_software_name;
                                int n;

                                Console.WriteLine("Selected to Search For Software Name :- ");
                                Console.WriteLine();
                                Console.Write("Enter the Name of Software To Search : ");
                                v_search_software_name = Console.ReadLine();

                                List<string> software_name = new List<string>();

                                for (n = 0; n < noSoftwares; n++)
                                {
                                    software_name.Add(softwares[n].software_name);
                                    Console.WriteLine();
                                }
                                if (software_name.Contains(v_search_software_name))
                                {
                                    Console.Write("There is a Software with the Name : ");
                                    Console.WriteLine(v_search_software_name);
                                }
                                else
                                {
                                    Console.Write("No Details of the Software Exist with Namee : ");
                                    Console.WriteLine(v_search_software_name);
                                }
                                break;
                            }
                    }
                    Console.WriteLine("----------------------------------------------------------------------");
                    break;
                case 4:
                    Console.WriteLine("Update an Asset : ");
                    Console.WriteLine();
                    Console.Write("Pls Select B - Books,S - Software,H - Hardware : ");
                    Char UpdateAssetType = Char.Parse(Console.ReadLine());
                    switch (UpdateAssetType)
                    {
                        case ('B' or 'b'):
                            {
                                string v_update_book_name, v_update_book_author, v_update_book_dop;
                                int n;

                                Console.WriteLine("Selected the Book Details to Update:- ");
                                Console.WriteLine();
                                Console.Write("Enter the Name of Book To Update : ");
                                v_update_book_name = Console.ReadLine();
                                Console.WriteLine();
                                Console.Write("Enter the Name of New Author : ");
                                v_update_book_author = Console.ReadLine();
                                Console.WriteLine();
                                Console.Write("Enter the Name of New Date Of Publishing : ");
                                v_update_book_dop = Console.ReadLine();
                                Console.WriteLine();
                                for (n = 0; n < noBooks; n++)
                                {
                                    if (books[n].book_name.Contains(v_update_book_name))
                                    {
                                        books.Where(b => b.book_name == v_update_book_name).Select(b => { b.book_author = v_update_book_author; b.book_dop = v_update_book_dop; return b; }).ToList();
                                        Console.Write("Book Details Updated with Name : ");
                                        Console.WriteLine(v_update_book_name);
                                    }
                                }
                                for (x = 0; x < noBooks; x++)
                                {
                                    Console.WriteLine("Serial = {1}, Title = {2},  Author = {3},  DOP = {4}", x + 1, books[x].serial_no, books[x].book_name, books[x].book_author, books[x].book_dop);
                                }
                                break;
                            }
                        case ('H' or 'h'):
                            {
                                string v_update_hardware_type;
                                int n, v_update_hardware_qty;
                                double v_update_hardware_price;

                                Console.WriteLine("Selected the Hardware Details to Update:- ");
                                Console.WriteLine();
                                Console.Write("Enter the Type of Hardware To Update : ");
                                v_update_hardware_type = Console.ReadLine();
                                Console.WriteLine();
                                Console.Write("Enter the New Price of Hardware : ");
                                v_update_hardware_price = Convert.ToDouble(Console.ReadLine()); ;
                                Console.WriteLine();
                                Console.Write("Enter the New Qty of Hardware : ");
                                v_update_hardware_qty = Convert.ToInt32(Console.ReadLine()); ;
                                Console.WriteLine();
                                for (n = 0; n < noHardwares; n++)
                                {
                                    if (hardwares[n].hardware_type.Contains(v_update_hardware_type))
                                    {
                                        hardwares.Where(b => b.hardware_type == v_update_hardware_type).Select(b => { b.hardware_price = v_update_hardware_price; b.hardware_qty = v_update_hardware_qty; return b; }).ToList();

                                        Console.Write("Hardware Details Updated with Type : ");
                                        Console.WriteLine(v_update_hardware_type);
                                    }
                                }
                                for (y = 0; y < noHardwares; y++)
                                {
                                    Console.WriteLine("Serial = {1}, Type = {2},  Price = {3},  Qty = {4}", y + 1, hardwares[y].serial_no, hardwares[y].hardware_type, hardwares[y].hardware_price, hardwares[y].hardware_qty);
                                }
                                break;
                            }
                        case ('S' or 's'):
                            {
                                string v_update_software_name, v_update_license_no, v_update_license_desc;
                                int n;

                                Console.WriteLine("Selected the Software Details to Update:- ");
                                Console.WriteLine();
                                Console.Write("Enter the Name of Software To Update : ");
                                v_update_software_name = Console.ReadLine();
                                Console.WriteLine();
                                Console.Write("Enter the New Licence No of Software : ");
                                v_update_license_no = Console.ReadLine();
                                Console.WriteLine();
                                Console.Write("Enter the New Licence Description of Software : ");
                                v_update_license_desc = Console.ReadLine();
                                Console.WriteLine();

                                for (n = 0; n < noSoftwares; n++)
                                {
                                    if (softwares[n].software_name.Contains(v_update_software_name))
                                    {
                                        softwares.Where(b => b.software_name == v_update_software_name).Select(b => { b.license_no = v_update_license_no; b.license_desc = v_update_license_desc; return b; }).ToList();

                                        Console.Write("Software Details Updated with Type : ");
                                        Console.WriteLine(v_update_software_name);
                                    }
                                }
                                for (z = 0; z < noSoftwares; z++)
                                {
                                    Console.WriteLine("Serial = {1}, Name = {2},  Licence No = {3},  Licence Description = {4}", z + 1, softwares[z].serial_no, softwares[z].software_name, softwares[z].license_no, softwares[z].license_desc);
                                }
                                break;
                            }
                    }
                    Console.WriteLine("-------------------------------------------------------------------------");
                    break;
                case 5:
                    Console.WriteLine("Delete an Asset");
                    Console.WriteLine();
                    Console.Write("Pls Select B - Books,S - Software,H - Hardware : ");
                    Char DeleteAssetType = Char.Parse(Console.ReadLine());
                    switch (DeleteAssetType)
                    {
                        case ('B' or 'b'):
                            {
                                string v_delete_book_name;
                                int n;

                                Console.WriteLine("Selected the Book Details to Delete:- ");
                                Console.WriteLine();
                                Console.Write("Enter the Name of Book To Delete : ");
                                v_delete_book_name = Console.ReadLine();
                                for (n = 0; n < noBooks; n++)
                                {
                                    if (books[n].book_name.Contains(v_delete_book_name))
                                    {
                                        books.RemoveAt(n);
                                        Console.Write("Book Details Deleted with Name : ");
                                        Console.WriteLine(v_delete_book_name);
                                        Console.WriteLine("");
                                        Console.WriteLine("Available Book List : ");
                                        noBooks = noBooks - 1;
                                        break;
                                    }
                                }
                                for (x = 0; x < noBooks; x++)
                                {
                                    Console.WriteLine("Serial = {1}, Title = {2},  Author = {3},  DOP = {4}", x + 1, books[x].serial_no, books[x].book_name, books[x].book_author, books[x].book_dop);
                                }
                                break;
                            }
                        case ('H' or 'h'):
                            {
                                string v_delete_hardware_type;
                                int n;

                                Console.WriteLine("Selected the Hardware Details to Delete:- ");
                                Console.WriteLine();
                                Console.Write("Enter the Type of Hardware To Delete : ");
                                v_delete_hardware_type = Console.ReadLine();

                                for (n = 0; n < noHardwares; n++)
                                {
                                    if (hardwares[n].hardware_type.Contains(v_delete_hardware_type))
                                    {
                                        hardwares.RemoveAt(n);
                                        Console.Write("Hardware Details Deleted with Type : ");
                                        Console.WriteLine(v_delete_hardware_type);
                                        noHardwares = noHardwares - 1;
                                        break;
                                    }
                                }
                                for (y = 0; y < noHardwares; y++)
                                {
                                    Console.WriteLine("Serial = {1}, Type = {2},  Price = {3},  Qty = {4}", y + 1, hardwares[y].serial_no, hardwares[y].hardware_type, hardwares[y].hardware_price, hardwares[y].hardware_qty);
                                }
                                break;
                            }
                        case ('S' or 's'):
                            {
                                string v_delete_software_name;
                                int n;

                                Console.WriteLine("Selected the Software Details to Delete:- ");
                                Console.WriteLine();
                                Console.Write("Enter the Name of Software To Delete : ");
                                v_delete_software_name = Console.ReadLine();

                                for (n = 0; n < noSoftwares; n++)
                                {
                                    if (softwares[n].software_name.Contains(v_delete_software_name))
                                    {
                                        softwares.RemoveAt(n);
                                        Console.Write("Software Details Deleted with Name : ");
                                        Console.WriteLine(v_delete_software_name);
                                        noSoftwares = noSoftwares - 1;
                                        break;
                                    }
                                }
                                for (z = 0; z < noSoftwares; z++)
                                {
                                    Console.WriteLine("Serial = {1}, Name = {2},  Licence No = {3},  Licence Description = {4}", z + 1, softwares[z].serial_no, softwares[z].software_name, softwares[z].license_no, softwares[z].license_desc);
                                }
                                break;
                            }
                    }
                    Console.WriteLine("-------------------------------------------------------------------------");
                    break;
                case 6:
                    Console.WriteLine("Exit...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("NO DATA FOUND");
                    break;
            }
            Console.WriteLine("\n\n");
            goto Start;
        }
    }
}