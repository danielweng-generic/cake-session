#addin nuget:?package=Newtonsoft.Json&version=12.0.3
#addin nuget:?package=Cake.FileHelpers&version=3.2.1

#load builddata.cake

using Newtonsoft.Json;

public static class ConfigTasks
{
    public const string SetConfigValues = "Set-Config-Values";
}

Task(ConfigTasks.SetConfigValues)
    .Does<Builddata>(builddata =>{
        var configPath = GetFiles("../**/config.json").Single();
        var configFileText = FileReadText(configPath);

        var config = JsonConvert.DeserializeObject<Config>(configFileText);

        config.ConfigurationInteger = builddata.ConfigInteger;
        config.ConfigurationString = builddata.ConfigString;

        configFileText = JsonConvert.SerializeObject(config);

        FileWriteText(configPath, configFileText);
});


public class Config 
{
    public string ConfigurationString { get; set; }

    public int ConfigurationInteger { get; set; }
}