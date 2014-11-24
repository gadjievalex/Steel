/*
 * Сделано в SharpDevelop.
 * Пользователь: GadjievAlex
 * Дата: 23.11.2014
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;

using Steel_Fundamental_.by.Steel.GadjievAlex.ComputerClass.PCParts;
using Steel_Fundamental_.by.Steel.GadjievAlex.ComputerClass.PCs;
using Steel_Fundamental_.by.Steel.GadjievAlex.ComputerClass.software;
using Steel_Fundamental_.by.Steel.GadjievAlex.ComputerClass.software.programms;
using Steel_Fundamental_.by.Steel.GadjievAlex.scrapmetal;

namespace Steel_Fundamental_.by.Steel.GadjievAlex.ComputerClass
{
	/// <summary>
	/// Description of Admin.
	/// </summary>
	public class Admin
	{
		private PCClass instanceCompClass;
		
		private List<PC>compToBuy=new List<PC>();
		
		private List<Scrapmetal>scrapMetal=new List<Scrapmetal>();
		
		public Admin()
		{
			Console.WriteLine("начался новый день админа компьютерного класса ");
		}
		
		public void takeManagement(PCClass clas)
		{
			if (clas != null)
			{
				instanceCompClass=clas; 
				Console.WriteLine("админ взял под опеку класс компьютерный");
			}
		}
		
		public void sees(Object obj, bool? like)
		{
			Console.WriteLine(string.Format("увидел {0}",obj.GetType().Name));
			
			switch(obj is PC)
			{
				case true:
					switch(like)
			          {
			          	case true:
							compToBuy.Add((PC)obj);
			          		Console.WriteLine(string.Format("компьютер {0} понравился решил купить",obj.GetType().Name));
			          		break;
			          	case false:
			          		Console.WriteLine(string.Format("компьютер {0} не понравился, решил не покупать",obj.GetType().Name));
			          		break;
			          	default:
			          		Console.WriteLine(string.Format("совсем без эмоций оставил его {0}, решил не покупать",obj.GetType().Name));
			          		break;
			          }
					break;
				case false:
					//scrapMetal.Add((Scrapmetal)obj);
					Console.WriteLine(string.Format("возможно {0} - это металлолм, надо будет собрать",obj.GetType().Name));
					break;
					
			}
	          
		}
		public void buyPC()
		{
			foreach(PC comp in compToBuy)
			{
				instanceCompClass.subtractBudget(comp.getPrice());
				Console.WriteLine(string.Format("взял из бюджета класса {0}",comp.getPrice()));
				Console.WriteLine(string.Format("купил компьютер {0}",comp.GetType().Name));
				instanceCompClass.placePC(comp);
			}
		}
		
		public void TurnOnnComps()
		{
			Console.WriteLine(string.Format("решил повключать компьютеры в классе"));
			
			foreach(PC comp in AdminGetRoundPC())
			{
				Console.WriteLine(string.Format("включил компьютер {0} ",comp.GetType().Name));
				comp.TurnON();
			}
		}
		
		public void InstallSoft()
		{
			Console.WriteLine(string.Format("решил установить soft"));
			
			Soft kasper = new Kasper();
			
			Soft wundows = new Wundows();
			
			instanceCompClass.InstallSoft(wundows);
			instanceCompClass.InstallSoft(kasper);
			instanceCompClass.InstallSoft(wundows);
		}
		
		public void RestartsComputers()
		{
			Console.WriteLine(string.Format("решил поперезагружать компьютеры в классе"));
			
			foreach(PC comp in AdminGetRoundPC())
			{
				Console.WriteLine(string.Format("перезагружает компьютер {0} ",comp.GetType().Name));
				comp.Rebut();
			}
		}
		private IEnumerable<PC> AdminGetRoundPC()
		{
			//тут админ просто ходит от компьютера к компьютеру
			return instanceCompClass.getPlacedPC();
		}
			
		
		public void Scrapmetalharvest()
		{
			Console.WriteLine(string.Format("собирает неработающие комплектующие"));
			
			foreach(PC comp in AdminGetRoundPC())
			{
				List<PCPart>parts=comp.getParts();
				
				foreach(PCPart part in parts)
				{
					if(part.isPartBroken())
					{
						Console.WriteLine(part.isPartBroken()+"broken");
						scrapMetal.Add((Scrapmetal)part);
					}
				}
			}
			Console.WriteLine("металлолома собрано {0}",scrapMetal.Count);
		}
		//этот метод должен называться вроде InstallPart но для конкретного примера именно установка платы
		public void InstallMainDoard()
		{
			PCPart main=new MainBoard();
			Console.WriteLine("устанавливает материнские платы");
			foreach(PC comp in AdminGetRoundPC())
			{
				comp.setParts(main);
			}
		}
		
		public void RepairComp()
		{
			PCPart newBoard=new MainBoard();
			
			instanceCompClass.RepairComp("Dell", newBoard);
		}
		
		public void SellPC(string compToSell)
		{
			instanceCompClass.SellComp(compToSell);
		}
		
		public void sleep()
		{
			Console.WriteLine("Конец");
		}
	}
}
