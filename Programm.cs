/*
 * Сделано в SharpDevelop.
 * Пользователь: GadjievAlex
 * Дата: 23.11.2014
 */
using System;
using Steel_Fundamental_.by.Steel.GadjievAlex.ComputerClass;
using Steel_Fundamental_.by.Steel.GadjievAlex.ComputerClass.PCs;
using Steel_Fundamental_.by.Steel.GadjievAlex.ComputerClass.PCs.otherPC;
using Steel_Fundamental_.by.Steel.GadjievAlex.scrapmetal;

namespace Steel_Fundamental_
{
	/// <summary>
	/// Description of Programm.
	/// </summary>
	public class Programm
	{
		private static Admin admin = new Admin();
		
		private static PCClass pcClass = new PCClass();
		
		public static void Main()
		{
			//начался день, или ночь..
			NewDayBegin();
			//покупка компьютеров
			Computerbuying();
			//установка комплектующей
			SetMainBoard();
			//их включение
			TurnOnnComputers();
			//установка программ
			InstallProgramms();
			//перезагрузка
			Rebutcomputers();
			//поломалась плата на компьютере
			BoardCrash();
			//ищет и меняет сломанную комплектующую
			//устанавливает новую плату в делл
			RepairComputer();
			//сбор металлолома
			Scrapmetalharvest();
			//продает компьютер Dell
			SellPC();
			//Конец
			EndAdminDay();
			
			Console.ReadLine();
		}		
		
		private static void NewDayBegin()
		{
			admin.takeManagement(pcClass);
			
			PC dell=new Dell();
			admin.sees(dell, true);
			
			PC customPC=new CustomPC();
			admin.sees(customPC, true);
			
			Scrapmetal rusty = new Scrapmetal();
			admin.sees(rusty, null);
			
			BadPC badPC=new BadPC();
			admin.sees(badPC,null);
		}
		
		private static void Computerbuying()
		{
			Console.WriteLine("начал покупать понравившиеся компьютеры");
			admin.buyPC();
		}
		
		static void SetMainBoard()
		{
			admin.InstallMainDoard();
		}
		
		static void TurnOnnComputers()
		{
			admin.TurnOnnComps();
		}
		
		static void InstallProgramms()
		{
			admin.InstallSoft();
		}
		
		static void Rebutcomputers()
		{
			admin.RestartsComputers();
		}
		static void BoardCrash()
		{
			pcClass.CrushComputer("Dell");
		}
		
		static void Scrapmetalharvest()
		{
			admin.Scrapmetalharvest();
		}

		static void RepairComputer()
		{
			admin.RepairComp();
		}
		
		static void SellPC()
		{
			admin.SellPC("Dell");
		}
		
		static void EndAdminDay()
		{
			admin.sleep();
		}		
	}
}
