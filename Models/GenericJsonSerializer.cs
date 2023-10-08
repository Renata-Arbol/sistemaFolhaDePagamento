using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using sistemaFolhaDePagamento.Models;
public class GenericJsonSerializer
{
    private readonly ApplicationDbContext _context;

    public GenericJsonSerializer(ApplicationDbContext context)
    {
        _context = context;
    }

public void SerializeAndSave<T>(T data) where T : class
{
    var options = new JsonSerializerOptions
    {
        ReferenceHandler = ReferenceHandler.Preserve,
        // Outras configurações, se necessário
    };

    // Serializar o objeto para uma string JSON
    string jsonString = JsonSerializer.Serialize(data, options);

    // Desserializar a string JSON de volta para o objeto do tipo T
    T deserializedData = JsonSerializer.Deserialize<T>(jsonString, options);

    // Anexar o objeto ao contexto (ou adicioná-lo se ele não existir)
    var entry = _context.Entry(deserializedData);
    if (entry.State == EntityState.Detached)
    {
        _context.Set<T>().Add(deserializedData);
    }

    // Salvar as alterações no banco de dados
    _context.SaveChanges();
}

}
