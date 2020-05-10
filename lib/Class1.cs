using System.Drawing;

namespace ds.test.impl
{
    internal abstract class IntMathFunctions
    {
        public abstract int Calculate(int a, int b);
    }

    public interface IPlugin
    {
        string PluginName { get; }
        string Version { get; }
        System.Drawing.Image Image { get; }
        string Description { get; }
        int Run(int input1, int input2);
    }

    internal interface PluginFactory
    {
        int PluginsCount { get; }
        string[] GetPluginNames { get; }
        IPlugin GetPlugin(string pluginName);
    }

    public class Plugins : PluginFactory
    {
        public Plugins()
        {
            GetPluginNames = new string[]{"Add", "Substract", "GCD", "Multiply" };
            PluginsCount = GetPluginNames.Length;
        }

        public int PluginsCount { get; }

        public string[] GetPluginNames { get; }

        public IPlugin GetPlugin(string pluginName)
        {
            switch(pluginName)
            {
                case "Add": return new AddingPlugin();
                case "Substract": return new SubtractionPlugin();
                case "Multiply": return new MultiplyPlugin();
                case "GCD": return new GCDPlugin();
                case "LCM": return new LCMPlugin();
                default: return null;
            }
        }
    }

    internal class AddingPlugin : IPlugin
    {
        public AddingPlugin()
        {
            PluginName = "Adding Plugin";
            Version = "1.0.0";
            Description = "Plugin that add two integers";
        }

        public string PluginName { get; }

        public string Version { get; }

        public Image Image { get; }

        public string Description { get; }

        public int Run(int input1, int input2)
        {
            return input1 + input2;
        }
    }

    internal class SubtractionPlugin : IPlugin
    {
        public SubtractionPlugin()
        {
            PluginName = "Minus Plugin";
            Version = "1.0.0";
            Description = "Plugin that subtract two integers";
        }

        public string PluginName { get; }

        public string Version { get; }

        public Image Image { get; }

        public string Description { get; }

        public int Run(int input1, int input2)
        {
            return input1 - input2;
        }
    }

    internal class MultiplyPlugin : IPlugin
    {
        public MultiplyPlugin()
        {
            PluginName = "Multiply Plugin";
            Version = "1.0.0";
            Description = "Plugin that multiply two integers";
        }

        public string PluginName { get; }

        public string Version { get; }

        public Image Image { get; }

        public string Description { get; }

        public int Run(int input1, int input2)
        {
            return input1 * input2;
        }
    }

    internal class GCDPlugin : IntMathFunctions, IPlugin
    {
        public GCDPlugin()
        {
            PluginName = "GCD Plugin";
            Version = "1.0.0";
            Description = "Plugin that find great common diviser of two integers";
        }

        public string PluginName { get; }

        public string Version { get; }

        public Image Image { get; }

        public string Description { get; }

        public int Run(int input1, int input2)
        {
            return Calculate(input1, input2);
        }

        public override int Calculate(int a, int b)
        {
            int t;
            while (b != 0)
            {
                t = b;
                b = a % b;
                a = t;
            }
            return a;
        }
    }

    internal class LCMPlugin : IntMathFunctions, IPlugin
    {
        private int abs(int x)
        {
            return (x < 0) ? -x : x;
        }

        public LCMPlugin()
        {
            PluginName = "LCM Plugin";
            Version = "1.0.0";
            Description = "Plugin that find least common multiple of two integers";
        }

        public string PluginName { get; }

        public string Version { get; }

        public Image Image { get; }

        public string Description { get; }

        public int Run(int input1, int input2)
        {
            return Calculate(input1, input2);
        }

        public override int Calculate(int a, int b)
        {
            int t;
            while (b != 0)
            {
                t = b;
                b = a % b;
                a = t;
            }
            return abs(a * b)/a;
        }
    }
}
