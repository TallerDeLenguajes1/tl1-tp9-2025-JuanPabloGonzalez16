

using System.Runtime.CompilerServices;

string? path;

bool existe;
do{
    Console.WriteLine("Ingrese el path de un directorio que desea analizar");
    path = Console.ReadLine();
    existe = Directory.Exists(path);
    if(!existe){
        Console.WriteLine("Path invalido, Ingresar de nuevo");
    }
}while(!existe);
if(existe){
    Console.WriteLine("La direccion ingresada es valida");
    string[] carpetas = Directory.GetDirectories(path);
    string[] archivos = Directory.GetFiles(path);
    if(carpetas == null){
        Console.WriteLine("No hay carpetas dentro");
    }else{
        Console.WriteLine("Carpetas");
        foreach(var car in carpetas){
            Console.WriteLine(car);
        }
    }
    if(archivos == null){
        Console.WriteLine("No hay archivos dentro");
    }else{
        Console.WriteLine("Archivos");
        foreach(var arc in archivos){
            FileInfo info = new FileInfo(arc);
            double tamanoKB = info.Length / 1024;
            Console.WriteLine("Nombre Archivo : " + arc  + "Tamaño : " + tamanoKB + "KB");
        }
    }
    
    
    List<string> LineaCsv = new List<string>{
        "Nombre;Tamaño;Accedido"
    };
    foreach(var arc in archivos){
        FileInfo informacion = new FileInfo(arc);
        string nombre = informacion.Name;
        double tamanokb = informacion.Length / 1024;
        DateTime fec = informacion.LastWriteTime;
        string linea = $"{nombre};{tamanokb};{fec}"; 
        LineaCsv.Add(linea);
    }
    
    string ruta = Path.Combine(path, "reporte_archivos.csv");
    File.WriteAllLines(ruta,LineaCsv);
}