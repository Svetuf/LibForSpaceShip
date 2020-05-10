using System.Drawing;

namespace ds.test.impl
{
    /// <summary>
    /// An abstract class that represents a base for
    /// classes of large mathematical calculations.
    /// </summary>
    internal abstract class IntMathFunctions
    {
        /// <summary>
        /// Calculus function.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>
        /// Result of calculating function.
        /// </returns>
        public abstract int Calculate(int a, int b);
    }

    /// <summary>
    /// Basic interface for plugin.
    /// </summary>
    public interface IPlugin
    {
        string PluginName { get; }
        string Version { get; }
        System.Drawing.Image Image { get; }
        string Description { get; }
        int Run(int input1, int input2);
    }

    /// <summary>
    /// Plugin factory interface.
    /// </summary>
    internal interface PluginFactory
    {
        int PluginsCount { get; }
        string[] GetPluginNames { get; }
        IPlugin GetPlugin(string pluginName);
    }

    /// <summary>
    /// Class for work with plugins.
    /// </summary>
    public class Plugins : PluginFactory
    {
        public Plugins()
        {
            GetPluginNames = new string[]{ "Adding Plugin", "Substraction Plugin",
                "Multiply Plugin", "GCD Plugin", "LCM Plugin" };
            PluginsCount = GetPluginNames.Length;
        }

        /// <summary>
        /// Count of total availible types of Plugin.
        /// </summary>
        public int PluginsCount { get; }

        /// <summary>
        /// All allow names of Plugins.
        /// </summary>
        public string[] GetPluginNames { get; }

        /// <summary>
        /// Create new Plugin bject based on given param.
        /// </summary>
        /// <param name="pluginName">Name of plugin to create, see <see cref="Plugins.PluginsCount"/>.</param>
        /// <returns>Created plugin.</returns>
        public IPlugin GetPlugin(string pluginName)
        {
            for(int i = 0; i < PluginsCount; i++)
                if(pluginName == GetPluginNames[i])
                {
                    switch (i)
                    {
                        case 0: return new AddingPlugin();
                        case 1: return new SubtractionPlugin();
                        case 2: return new MultiplyPlugin();
                        case 3: return new GCDPlugin();
                        case 4: return new LCMPlugin();
                    }

                }
            return null;
        }
    }

    /// <summary>
    /// Plugin that add two integers.
    /// </summary>
    internal class AddingPlugin : IPlugin
    {
        public AddingPlugin()
        {
            PluginName = "Adding Plugin";
            Version = "1.0.0";
            Description = "Plugin that add two integers";
        }

        /// <summary>
        /// Name of this plugin, uses in <see cref="Plugins.GetPlugin(string)"/>.
        /// </summary>
        public string PluginName { get; }

        /// <summary>
        /// Version of this plugin.
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// Image of plugin.
        /// </summary>
        public Image Image { get; }

        /// <summary>
        /// Description of this plugin.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Calculating method.
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns></returns>
        public int Run(int input1, int input2)
        {
            return input1 + input2;
        }
    }

    /// <summary>
    /// Plugin that substract two integers.
    /// </summary>
    internal class SubtractionPlugin : IPlugin
    {
        public SubtractionPlugin()
        {
            PluginName = "Substraction Plugin";
            Version = "1.0.0";
            Description = "Plugin that subtract two integers";
        }
        /// <summary>
        /// Name of this plugin, uses in <see cref="Plugins.GetPlugin(string)"/>.
        /// </summary>
        public string PluginName { get; }

        /// <summary>
        /// Version of this plugin.
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// Image of plugin.
        /// </summary>
        public Image Image { get; }

        /// <summary>
        /// Description of this plugin.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Calculating method.
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns></returns>
        public int Run(int input1, int input2)
        {
            return input1 - input2;
        }
    }

    /// <summary>
    /// Plugin that multiply two integers.
    /// </summary>
    internal class MultiplyPlugin : IPlugin
    {
        public MultiplyPlugin()
        {
            PluginName = "Multiply Plugin";
            Version = "1.0.0";
            Description = "Plugin that multiply two integers";
        }

        // <summary>
        /// Name of this plugin, uses in <see cref="Plugins.GetPlugin(string)"/>.
        /// </summary>
        public string PluginName { get; }

        /// <summary>
        /// Version of this plugin.
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// Image of plugin.
        /// </summary>
        public Image Image { get; }

        /// <summary>
        /// Description of this plugin.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Calculating method.
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns></returns>
        public int Run(int input1, int input2)
        {
            return input1 * input2;
        }
    }

    /// <summary>
    /// Plugin that find great common diviser of two integers.
    /// </summary>
    internal class GCDPlugin : IntMathFunctions, IPlugin
    {
        public GCDPlugin()
        {
            PluginName = "GCD Plugin";
            Version = "1.0.0";
            Description = "Plugin that find great common diviser of two integers";
        }

        /// <summary>
        /// Name of this plugin, uses in <see cref="Plugins.GetPlugin(string)"/>.
        /// </summary>
        public string PluginName { get; }

        /// <summary>
        /// Version of this plugin.
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// Image of plugin.
        /// </summary>
        public Image Image { get; }

        /// <summary>
        /// Description of this plugin.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Method that run calculating.
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns>GCD of two integers</returns>
        public int Run(int input1, int input2)
        {
            return Calculate(input1, input2);
        }

        /// <summary>
        /// Calculating a GCD of two integers.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>GCD.</returns>
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

    /// <summary>
    /// "Plugin that find least common multiple of two integers".
    /// </summary>
    internal class LCMPlugin : IntMathFunctions, IPlugin
    {
        /// <summary>
        /// Asolute value of two integers.
        /// </summary>
        /// <param name="x"></param>
        /// <returns>Asolute value of two integers.</returns>
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

        /// <summary>
        /// Name of this plugin, uses in <see cref="Plugins.GetPlugin(string)"/>.
        /// </summary>
        public string PluginName { get; }

        /// <summary>
        /// Version of this plugin.
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// Image of plugin.
        /// </summary>
        public Image Image { get; }

        /// <summary>
        /// Description of this plugin.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Method that run calculating.
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns>LCM of two integers</returns>
        public int Run(int input1, int input2)
        {
            return Calculate(input1, input2);
        }

        /// <summary>
        /// Calculating a LCM of two integers.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>LCM.</returns>
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
