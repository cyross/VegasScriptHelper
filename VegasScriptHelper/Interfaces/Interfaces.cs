using ScriptPortal.Vegas;
using YamlDotNet.RepresentationModel;

namespace VegasScriptHelper.Interfaces
{
    public interface IEntryPoint
    {
        void FromVegas(Vegas vegas);
    }

    public interface IExtProc
    {
        void Exec();
    }

    public interface IYamlSpec
    {
        void Deserialize(YamlStream stream);
        bool Contains(string name);
    }

}
