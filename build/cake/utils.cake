
public FilePath ResolveTool(string file)
{
    return GetFiles($"./tools/**/{file}").FirstOrDefault();
}   
