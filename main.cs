using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

class MemoryGame {
  
  static bool sound = true;
  static int lvl = 3;
  static List<int> outList = new List<int>();
  static List<int> inList = new List<int>();
  
  static void Main() {
      Console.Clear();
      
      Console.WriteLine("\n<---***--->\nMemory Game\n<---***--->\n");
      Console.WriteLine("<--Commands-->\n'play'\n'settings'\n'level'\n");
      
      Beep();
      
      var a = 1;
      while(a == 1) {
          var command = Console.ReadLine();
          
          Beep();
          
          if(command == "play") {
              a = 0;
              Game();
          } else if(command == "settings") {
              a = 0;
              Settings();
          } else if(command == "level") {
              a = 0;
              LevelSelect();
          } else {
              Console.WriteLine("<<INVALID COMMAND>>");
          }
      }
  }
  
  static void LevelSelect() {
      Console.Clear();
      
      Console.WriteLine("\n<---***--->\nLevel Select\n<---***--->\n");
      Console.WriteLine("Input any number equal to the level you want to play.\n");
      
      lvl = Convert.ToInt32(Console.ReadLine());
      
      Console.Clear();
      Console.WriteLine("\nYou selected level " + Convert.ToString(lvl));
      Thread.Sleep(1000);
      
      Main();
  }
  
  static void Game() {
      Console.Clear();
      
      int i;
      
      for(i = lvl; i > 0; i--) {
          
          Beep();
          
          Random rnd = new Random();
          int num = rnd.Next(1, 4);
          
          switch(num) {
              
              case 1:
                Console.WriteLine("|¤| | |");
                outList.Add(1);
                break;
              case 2:
                Console.WriteLine("| |¤| |");
                outList.Add(2);
                break;
              case 3:
                Console.WriteLine("| | |¤|");
                outList.Add(3);
                break;
          }
          
          Thread.Sleep(1500);
          
          Console.Clear();
          Console.WriteLine("| | | |");
          Thread.Sleep(500);
          Console.Clear();
          
      }
      
      Console.WriteLine("\nYour turn!");
      Beep();
      Thread.Sleep(1500);
      Console.Clear();
      
      for(i = lvl; i > 0; i--) {
          
          switch(Console.ReadKey().Key) {
              
              case ConsoleKey.LeftArrow:
                Console.WriteLine("|¤| | |");
                inList.Add(1);
                break;
              case ConsoleKey.DownArrow:
                Console.WriteLine("| |¤| |");
                inList.Add(2);
                break;
              case ConsoleKey.RightArrow:
                Console.WriteLine("| | |¤|");
                inList.Add(3);
                break;
          }
          
          Beep();
          Thread.Sleep(700);
          Console.Clear();
          
      }
      
      if(inList.SequenceEqual(outList)) {
          
          Console.WriteLine("correct");
          Beep();
          Thread.Sleep(2000);
          inList.Clear();
          outList.Clear();
          Main();
          
      } else {
          
          Console.WriteLine("wrong");
          Beep();
          Thread.Sleep(2000);
          inList.Clear();
          outList.Clear();
          Main();
          
      }
      
  }
  
  static void Settings() {
      Console.Clear();
      
      Console.WriteLine("\n<---***--->\n Settings\n<---***--->\n");
      Console.WriteLine("<--Commands-->\n'reset'\n'color'\n'sound'\n'menu'\n");
      
      var a = 1;
      while(a == 1) {
          var command = Console.ReadLine();
          
          Beep();
          
          if(command == "reset") {
              a = 0;
              Console.ResetColor();
              sound = true;
              Settings();
          } else if(command == "color") {
              a = 0;
              Color();
          } else if(command == "sound") {
              a = 0;
              Sound();
          } else if(command == "menu") {
              a = 0;
              Main();
          } else {
              Console.WriteLine("<<INVALID COMMAND>>");
          }
      }
  }
  
  static void Sound() {
      Console.Clear();
      
      Console.WriteLine("\n<---***--->\n<--Sound-->\n<---***--->\n");
      Console.WriteLine("<--Commands-->\n'on'\n'off'\n");
      
      var a = 1;
      while(a == 1) {
          var command = Console.ReadLine();
          
          Beep();
          
          if(command == "on") {
              a = 0;
              sound = true;
          } else if(command == "off") {
              a = 0;
              sound = false;
          } else {
              Console.WriteLine("<<INVALID COMMAND>>");
          }
      }
      
      Settings();
  }
  
  static void Color() {
      Console.Clear();
      
      Console.WriteLine("\n<---***--->\n<--Color-->\n<---***--->\n");
      Console.WriteLine("<--Commands-->\n'red'\n'green'\n'blue'\n'default'\n");
      
      var a = 1;
      while(a == 1) {
          var command = Console.ReadLine();
          
          Beep();
          
          if(command == "red") {
              a = 0;
              Console.ForegroundColor = ConsoleColor.Red;
          } else if(command == "green") {
              a = 0;
              Console.ForegroundColor = ConsoleColor.Green;
          } else if(command == "blue") {
              a = 0;
              Console.ForegroundColor = ConsoleColor.Blue;
          } else if(command == "default") {
              a = 0;
              Console.ResetColor();
          } else {
              Console.WriteLine("<<INVALID COMMAND>>");
          }
      }
      
      Settings();
  }
  
  static void Beep() {
      
      if(sound) {
          Console.Beep();
      }
      
  }
}




