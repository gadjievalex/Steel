/*
 * Сделано в SharpDevelop.
 * Пользователь: GadjievAlex
 * Дата: 23.11.2014
 */
using System;
using System.Collections.Generic;
using Steel_Fundamental_.by.Steel.GadjievAlex.ComputerClass.PCParts;
using Steel_Fundamental_.by.Steel.GadjievAlex.ComputerClass.PCs;
using Steel_Fundamental_.by.Steel.GadjievAlex.ComputerClass.software;

namespace Steel_Fundamental_.by.Steel.GadjievAlex.ComputerClass
{
	/// <summary>
	/// Description of PCCLass.
	/// </summary>
	public class PCClass
	{
		//бюджет на оборудование класса - 6000$
		private int classBudget = 6000;
		
		private Dictionary<string, PC>placedPC=new Dictionary<string, PC>();
		
		public int ClassBudget 
		{
			get
			{ 
				return classBudget; 
			}
		}
		public void subtractBudget(int value)
		{
			int substr=value;
			classBudget-=substr;
		}
		
		public PCClass()
		{
			Console.WriteLine("компьютерный класс создан (кем то...) ");
		}
		
		public void placePC(PC comp)
		{
			Console.WriteLine(string.Format("после покупки компьютера {0} в в бюджете класса оcталось {1}",comp.GetType().Name,this.classBudget));
			placedPC.Add(comp.Name, comp);
			Console.WriteLine(string.Format("установил компьютер {0} в класс",comp.GetType().Name));
		}
		public IEnumerable<PC>getPlacedPC()
		{
			return placedPC.Values;
		}
		
		public void InstallSoft(Soft programm)
		{
			foreach(PC comp in placedPC.Values)
			{
				comp.InstallSoft(programm);			
			}
		}
		
		public void CrushComputer(string compName)
		{
			Console.WriteLine("ломается плата у Dell-a");
			foreach(String dmgCompName in placedPC.Keys)
			{
				if(dmgCompName.Equals(compName))
				{
					do
					{
						//тут страшно но поздно и спать хочется :-)
						((PCPart)placedPC[dmgCompName].getParts()[0]).DescreseResource();
					}
					//тут тоже
					while(!((PCPart)placedPC[dmgCompName].getParts()[0]).isPartBroken());
					
				}
			}
		}
		
		public void RepairComp(string compProdName, PCPart part)
		{
			List<PCPart>parts=placedPC[compProdName].getParts();
			
			foreach(PCPart instpart in parts)
			{
				if((instpart.GetType())==(part.GetType()))
				{
					placedPC[compProdName].RemovePart(instpart);
					break;
				}
			}
			placedPC[compProdName].setParts(part);
			Console.WriteLine("сломанная плата заменена");
		}
		
		public void SellComp(string compToSell)
		{
			classBudget+=placedPC[compToSell].getPrice();
			Console.WriteLine("Бюджет класса после продажи Dell-a стал {0}",this.ClassBudget);
			Console.WriteLine("Потому что Dell стоил - {0}",placedPC[compToSell].getPrice().ToString());
			placedPC.Remove(compToSell);
			
			Console.WriteLine("осталось компьютеров "+placedPC.Count);
		}
	}
}
