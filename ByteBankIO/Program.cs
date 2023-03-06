using ByteBankIO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        var enderecoDoArquivo = "contas.txt"; //Onde o arquivos está

        using(var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open)) //Fluxo de dados Recebe endereço e operação(abrir)
        {
            var numeroDeByteslidos = -1;
                 

            /*public override int Read(byte[] array, int offset, int count);
                public override int Read -> lê o arquivo, recebe três argumentos(byte[] array -> onde os bytes lidos serão armazenados (conhecido como buffer),
                                                                                    int offset -> delimita o indice em que o método irá começar a preencher o array,
                                                                                        int count -> quantas posições serão preenchidas);
            */

            var buffer = new byte[1024]; // 1KB. Armazena em um array os pedaços do arquivo

            while(numeroDeByteslidos != 0)
            {
                numeroDeByteslidos = fluxoDoArquivo.Read(buffer, 0, 1024);
                Console.WriteLine($"Bytes lidos: {numeroDeByteslidos}");
                EscreverBuffer(buffer, numeroDeByteslidos);
            }

       
            /*fluxoDoArquivo.Read(buffer, 0, 1024); ->public override int Read(byte[] array, int offset, int count);
                Lê da posição 0 até a 1024 em imprime os bytes até o final do arquivo e então passa a retornar zeros
            */

            fluxoDoArquivo.Close();

            Console.ReadLine();
        }        
    }

    static void EscreverBuffer(byte[] buffer, int bytesLidos) //Método que escreve na tela os bytes achados no arquivo, recebe o buffer (byte[] array) como parâmetro e é chamado no main
    {
        var utf8 = new UTF8Encoding();

        var texto = utf8.GetString(buffer, 0, bytesLidos);

        //public virtual string GetString(byte[] bytes, int index, int count);

        Console.Write(texto);

;

        /*foreach (var meuByte in buffer)
        {
            Console.Write(meuByte);
            Console.Write(" ");
        }
        */
    }
}