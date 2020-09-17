using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

class MemoryGame {
  
  static bool sound = true;
  static int lvl = 1;
  static List<int> outList = new List<int>();
  static List<int> inList = new List<int>();
  static bool played = false;
  static int lastScore;
  
  static void Main() {
      Console.Clear();
      
      Console.WriteLine("\n<---***--->\nMemory Game\n<---***--->\n");
      
      if(played) {
          
          if(lvl > 1) {
              
              Console.WriteLine("CURRENT SCORE: " + Convert.ToString(lvl - 1));
              
          } else {
              
              Console.WriteLine("LAST SCORE: " + Convert.ToString(lastScore));
              
          }
          
      }
      
      Console.WriteLine("\n<--Commands-->\n'play'\n'settings'\n");
      
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
          } else {
              Console.WriteLine("<<INVALID COMMAND>>");
          }
      }
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
          
          Thread.Sleep(1000);
          
          Console.Clear();
          Console.WriteLine("| | | |");
          Thread.Sleep(400);
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
          Thread.Sleep(500);
          Console.Clear();
          
      }
      
      if(inList.SequenceEqual(outList)) {
          
          Console.WriteLine("\n<--CORRECT-->\nCURRENT SCORE: " + Convert.ToString(lvl));
          Beep();
          Thread.Sleep(2000);
          inList.Clear();
          outList.Clear();
          lvl += 1;
          played = true;
          Main();
          
      } else {
          
          Console.WriteLine("\n<--WRONG-->\nFINAL SCORE: " + Convert.ToString(lvl - 1));
          Beep();
          Thread.Sleep(2000);
          inList.Clear();
          outList.Clear();
          lastScore = lvl - 1;
          lvl = 1;
          played = true;
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

