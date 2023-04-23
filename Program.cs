//namespace POC-PROVA-DE-CONCEITO
//{
using iTextSharp.text;
using iTextSharp.text.pdf;

class Program
  {
      static void Main(string[] args) 
      {
         Document doc = new Document(PageSize.A4);
         doc.SetMargins(40,40,40,40);
         doc.AddCreationDate();
         string caminho = @"C:\pdf\" + "relatorio.pdf";

            
            FileStream fs = new FileStream(caminho, FileMode.Create);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs /*fs*/);  
            doc.Open();

         //instancia do arquivo pdf
         //* PdfWriter write = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));
         //abrir o documento
         //* doc.Open();

         Paragraph titulo = new Paragraph();
         titulo.Font = new Font(Font.FontFamily.COURIER, 40);
         titulo.Alignment = Element.ALIGN_CENTER;
         titulo.Add("teste\n\n");
         doc.Add(titulo);

         Paragraph paragrafo = new Paragraph("", new Font(Font.NORMAL, 12));
         string conteudo = "Estamos adicionando conteudo Lorem Ipsum";
         paragrafo.Add(conteudo);
         doc.Add(paragrafo);
         
         //colocando uma tabela no meu pdf
         PdfPTable table = new PdfPTable(3);
         
         for (int i = 0; i <= 10; i++){
         //estou fazendo um for com exivição de 10 linhas 
         //na interação
         table.AddCell($"Linha {i}, Coluna 1");
         table.AddCell($"Linha {i}, Coluna 2");
         table.AddCell($"Linha {i}, Coluna 3");
         }
         doc.Add(table);
         //adicionando uma imagem
        /*
         string simg = "https://www.google.com.br/url?sa=i&url=https%3A%2F%2Fdetto.com.br%2Fpara-que-serve-um-servidor%2F&psig=AOvVaw2_5pkpfLX7pqJXjn0nlBR4&ust=1682174369134000&source=images&cd=vfe&ved=0CBEQjRxqFwoTCODv5ICau_4CFQAAAAAdAAAAABAF";
         Image img = Image.GetInstance(simg);
         img.ScaleAbsolute(100, 130);
         doc.Add(img);
         */
         //passo close para fechar o meu documento e gravar na pasta .pdf
         doc.Close();

         //mando o meu programa gravar os processos da minha maquina e abrir
         System.Diagnostics.Process.Start(caminho);
         
      }
  }
//}