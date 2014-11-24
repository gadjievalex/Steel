/*
 * Сделано в SharpDevelop.
 * Пользователь: GadjievAlex
 * Дата: 23.11.2014
 */
using System;
using System.Collections.Generic;
using Steel_Fundamental_.by.Steel.GadjievAlex.ComputerClass.PCParts;
using Steel_Fundamental_.by.Steel.GadjievAlex.ComputerClass.software;

namespace Steel_Fundamental_.by.Steel.GadjievAlex.ComputerClass.PCs
{
	/// <summary>
	/// Description of PC.
	/// </summary>
	/// 
	public abstract class PC
	{
		//цена компьютера
		private int compPrice;
		// состояние вкл, выкл
		private bool isOn=false;
		//установленные программы
		private List<Soft>apps;
		//марка компьютера
		public string Name
		{
			get;
			set;
		}
		//список установленных комплектующих
		private List<PCPart>parts;
		
		public PC()
		{
			
		}
		public PC(int price)
		{
			this.compPrice=price;
		}
		public int getPrice()
		{
			return this.compPrice;
		}
		public void TurnON()
		{
			if(!isOn)
			{
				Console.WriteLine("включается");
				this.isOn=true;
				Console.WriteLine("компьютер включен");
			}
			else
			{
				Console.WriteLine("компьютер уже включене кнопку лучше не дергать");
			}
		}
		public void Rebut()
		{
			if(isOn)
			{
				Console.WriteLine("выключается");
				this.isOn=false;
				TurnON();
			}
			else
			{
				Console.WriteLine("для начала компьюте нужно включить");
			}
		}
		public void InstallSoft(Soft apps)
		{
			if(this.apps==null)
			{
				this.apps=new List<Soft>();
				this.apps.Add(apps);
			}
			else
			{
				for(int i=0; i<this.apps.Count;i++)
				{
					if(!this.apps[i].Equals(apps))
					{
						this.apps.Add(apps);
						Console.WriteLine("софт установлен в {0} прогамм в компьютере {1}",Name,this.apps.Count.ToString());
					}
					else
					{
						Console.WriteLine("exception [этот софт уже установлен] <при попытке установить уже имеющуюся поргу>");
						return;
					}
				}
			}
		}
		public List<Soft> getInstalledSoft()
		{
			return apps;
		}
		
		public List<PCPart> getParts()
		{
			return this.parts;
		}
		public void setParts(PCPart parts)
		{
			if(this.parts==null)
			{
				this.parts=new List<PCPart>();
			}
			this.parts.Add(parts);
		}
		public void RemovePart(PCPart part)
		{
			this.parts.Remove(part);
		}
		public void CheckState()
		{
			throw new NotImplementedException();
		}
	}
}
