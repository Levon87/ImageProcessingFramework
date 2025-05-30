using System;
using System.Collections.Generic;
using ImageProcessingFramework.Plugins.Interfaces;

namespace ImageProcessingFramework.Services
{
    public class PluginRegistry
    {
        private readonly Dictionary<string, IImagePlugin> _plugins = new();

        public void Register(IImagePlugin plugin)
        {
            if (plugin == null)
            {
                throw new ArgumentNullException("Plugin cannot be null");
            }
            _plugins[plugin.GetType().Name] = plugin;
        }

        public void Remove(string pluginName) => _plugins.Remove(pluginName);

        public IImagePlugin Get(string pluginName)
        {
            return _plugins.TryGetValue(pluginName, out var plugin)
                ? plugin
                : throw new KeyNotFoundException($"Plugin '{pluginName}' not found");
        }

        public IEnumerable<IImagePlugin> GetAll() => _plugins.Values;
    }
}