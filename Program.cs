namespace Intro_to_design_pattern__Abstract_factory
{
    public abstract class Box { }
    public abstract class Processor { }
    public abstract class MainBoard { }
    public abstract class Hdd { }
    public abstract class Memory { }

    public class BlackBox : Box { }
    public class SilverBox : Box { }
    public class AmdProcessor : Processor { }
    public class IntelProcessor : Processor { }
    public class AsusMainBoard : MainBoard { }
    public class MSIMainBoard : MainBoard { }
    public class LGHDD : Hdd { }
    public class SamsungHDD : Hdd { }
    public class DdrMemory : Memory { }
    public class Ddr2Memory : Memory { }


    public interface IPCFactory
    {
        Box CreateBox();
        Processor CreateProcessor();
        MainBoard CreateMainBoard();
        Hdd CreateHdd();
        Memory CreateMemory();
    }
    public class OfficePcFactory : IPCFactory
    {
        public Box CreateBox() => new BlackBox();
        public Processor CreateProcessor() => new AmdProcessor();
        public MainBoard CreateMainBoard() => new AsusMainBoard();
        public Hdd CreateHdd() => new LGHDD();
        public Memory CreateMemory() => new DdrMemory();
    }
    public class HomePcFactory : IPCFactory
    {
        public Box CreateBox() => new SilverBox();
        public Processor CreateProcessor() => new IntelProcessor();
        public MainBoard CreateMainBoard() => new MSIMainBoard();
        public Hdd CreateHdd() => new SamsungHDD();
        public Memory CreateMemory() => new Ddr2Memory();
    }
    public class Pc
    {
        public Box Box { get; set; }
        public Processor Processor { get; set; }
        public MainBoard MainBoard { get; set; }
        public Hdd Hdd { get; set; }
        public Memory Memory { get; set; }
    }
    public class PcConfigurator
    {
        private IPCFactory _pcFactory;

        public PcConfigurator(IPCFactory pcFactory)
        {
            _pcFactory = pcFactory;
        }
        public void Configure(Pc pc)
        {
            pc.Box = _pcFactory.CreateBox();
            pc.Processor = _pcFactory.CreateProcessor();
            pc.MainBoard = _pcFactory.CreateMainBoard();
            pc.Hdd = _pcFactory.CreateHdd();
            pc.Memory = _pcFactory.CreateMemory();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            IPCFactory officeFactory = new OfficePcFactory();
            PcConfigurator officeConfigurator = new PcConfigurator(officeFactory);
            Pc officePc = new Pc();
            officeConfigurator.Configure(officePc);
            Console.WriteLine("Office PC configured with : ");
            Console.WriteLine(officePc.Box.GetType().Name);
            Console.WriteLine(officePc.Processor.GetType().Name);
            Console.WriteLine(officePc.MainBoard.GetType().Name);
            Console.WriteLine(officePc.Hdd.GetType().Name);
            Console.WriteLine(officePc.Memory.GetType().Name);

            IPCFactory homeFactory = new HomePcFactory();
            PcConfigurator homeConfigurator = new PcConfigurator(homeFactory);
            Pc homePc = new Pc();
            homeConfigurator.Configure(homePc);
            Console.WriteLine("\nHome PC configured with : ");
            Console.WriteLine(homePc.Box.GetType().Name);
            Console.WriteLine(homePc.Processor.GetType().Name);
            Console.WriteLine(homePc.MainBoard.GetType().Name);
            Console.WriteLine(homePc.Hdd.GetType().Name);
            Console.WriteLine(homePc.Memory.GetType().Name);
        }
    }
}