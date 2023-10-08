using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using sistemaFolhaDePagamento.Models; // Certifique-se de usar o namespace correto para o seu modelo de dados

public class RegistroPontoConverter : JsonConverter<RegistroPonto>
{
    public override RegistroPonto ReadJson(JsonReader reader, Type objectType, RegistroPonto existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        // Implemente a lógica de desserialização aqui, se necessário
        throw new NotImplementedException();
    }

    public override void WriteJson(JsonWriter writer, RegistroPonto value, JsonSerializer serializer)
    {
        if (value != null)
        {
            serializer.Serialize(writer, value);
        }
        else
        {
            writer.WriteNull();
        }
    }

}
