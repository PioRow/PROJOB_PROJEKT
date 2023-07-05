using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using System.Xml.Serialization;
using ExtendedXmlSerializer;
using ExtendedXmlSerializer.Configuration;
using ExtendedXmlSerializer.ExtensionModel.Content;

namespace PROJOB_PROJEKT
{
      
    public class queueCommand :ICommand
    {
        public new string Name => "queue";
        IBookstore bookstore;
        public string Buffer;
        public Queue<ICommand> done { get; set; }
        [XmlIgnore]
        private Dictionary<string, Action<string[]>> Actions;
        [XmlIgnore]
        private Dictionary<string, Action<string>> Serializers;
        private Dictionary<string,Action<string>> Deserializers;
        public string[] Args;     
         
        public Queue<ICommand> Commands { get; set; }
        
       
        public queueCommand()
        {  
        }
        
        public void Init(string[] Args,IBookstore bookstore,string? Meta)
        {
            this.Args = Args;
            this.bookstore = bookstore;
            done=new Queue<ICommand>();
            Actions = new Dictionary<string, Action<string[]>>();
            Serializers = new Dictionary<string, Action<string>>();
            Deserializers=new Dictionary<string, Action<string>>();
            Actions.Add("history", historyCommands);
         //   Actions.Add("commit", CommitCommands);
            Actions.Add("export", serializeCommands);
           // Actions.Add("dismiss", DismissCommands);
            Actions.Add("load", loadCommands);
            Serializers.Add("XML", XMLSerialization);
            Serializers.Add("plainText", PlainTextSerialization);
            Deserializers.Add("XML", XMLDeserialization);
            Deserializers.Add("plainText", PlainTextDeserialization);
            Actions.Add("undo", undoCommand);
            Actions.Add("redo", redoCommand);
            
            
        }
        public void Execute()
        {
            try
            {
                Action<string[]> ac=Actions[Args[1]];
                ac.Invoke(Args);
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
                Console.WriteLine("invalid queue operation");
              //  Commands.Clear();
            }
        }
        public void Undo()
        {

        }
        public void undoCommand(string[] Args)
        {

            ICommand com=Commands.First();
            com.Undo();
            done.Enqueue(com);
            Commands.Dequeue();
        }
        public void redoCommand(string[] Args)
        {
             ICommand com=done.First();
            com.Execute();
            Commands.Enqueue(com);
            done.Dequeue();
        }
        public void DismissCommands(string[] Args)
        {
            Commands.Clear();
        }
        public void CommitCommands(string[] Args)
        {
            foreach (var cmd in Commands)
            {
                try { cmd.Execute(); }
                catch { }
            }
            Commands.Clear();
        }
       
        public void historyCommands(string[] Args)
        {
            if(Commands.Count == 0) return;
            foreach (var cmd in Commands)
            {
                try
                {
                    Console.WriteLine(cmd);
                }
                catch { }
            }
        }
        public void XMLDeserialization(string file)
        {
           
            string xml = File.ReadAllText(file);
            IExtendedXmlSerializer serializer = new ConfigurationContainer().Create();
            Queue<ICommand> obj2 = serializer.Deserialize<Queue<ICommand>>(xml);
            foreach (var cmd in obj2)
            {
                cmd.Init(null, bookstore, null);
                Commands.Enqueue(cmd);
            }
        }
        public void PlainTextDeserialization(string file)
        {
            string ftext = File.ReadAllText(file);
           
            string[] comms=ftext.Split("|");
          for(int i=0;i<comms.Length-1;i++)
            { 
                string cmd = comms[i];
                
                CLI.Executer(cmd.Split("\n")[1], bookstore, cmd);
                
            }           
        }
        
        public void loadCommands(string[] Args)
        {
          
            var Deser = Deserializers[Args[3]];
            Deser.Invoke(Args[2]);
        }
        public void serializeCommands(string[] Args)
        {
            var serializaton = Serializers["XML"];
            
            if (Args.Count() == 4)
                serializaton = Serializers[Args[3]];
            serializaton.Invoke(Args[2]);
            Commands.Clear();

        }
        public void XMLSerialization(string file)
        {
            var serializer = new ConfigurationContainer().UseOptimizedNamespaces().Create();
            var xml = serializer.Serialize(Commands);
            
           using(StreamWriter sw = new StreamWriter(file))
            {
                sw.WriteLine(xml);
            }

        }
        public void PlainTextSerialization(string file)
        {
           
            using(StreamWriter sw = new StreamWriter(file))
            {
                sw.WriteLine();
                foreach(var cmd in Commands)
                {
                    sw.WriteLine(cmd+"|");
                }
            }
        }
    }

}
