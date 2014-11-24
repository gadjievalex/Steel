/*
 * Сделано в SharpDevelop.
 * Пользователь: GadjievAlex
 * Дата: 24.11.2014
 */
using System;
using Steel_Fundamental_.by.Steel.GadjievAlex.scrapmetal;

namespace Steel_Fundamental_.by.Steel.GadjievAlex.ComputerClass.PCParts
{
	/// <summary>
	/// Description of PCPart.
	/// </summary>
	public abstract class PCPart
	{
		//сломана или нет
		private bool isBroken = false; 
		
		//ресурс комплектующей
		private int resource;
		
		public PCPart(int resource)
		{
			this.resource=resource;
		}
		public bool isPartBroken()
		{
			return this.isBroken;
		}
		//выработка ресурса ма, если выраьотан - комп сломана -- металлолом
		public void DescreseResource()
		{
			if(!isBroken)
			{
				this.resource-=1;
				
				if(this.resource==0)
				{
					Console.WriteLine("сломано");
					this.isBroken=true;
				}
			}
		}
		//выполняет преобразование из комплектующей в металлолом
		public static explicit operator Scrapmetal(PCPart part)
    	{
			return new Scrapmetal();
		}
	}
}
