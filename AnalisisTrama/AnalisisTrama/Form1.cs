using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalisisTrama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string servicioEncapsulado = "";
        string Posiciones="";
        string Ncaracteres = "";//Incluye los dos espacios entre cada Byte (tomarlos en cuenta en Ncaracteres)
        //:::::::::::::::::::::::::::::::::::::::::::EVENTO ANALIZAR:::::::::::::::::::::::::::::::::::::::::::::::::
        private void BtnAnalizarTrama_Click(object sender, EventArgs e)
        {
            //TramaEthernet T;
            string tramaHexadecimal, direccionDestino, direccionOrigen, tipoServicio, informacion;
            

            //Leemos el archivo para traer la trama en binario
            string cadenaBinariaDeArchivo = File.ReadLines("Trama.txt").First();
            //Primer linea azul
            //TxtTramaBinario.SelectionColor = Color.DarkBlue;

            int cont = 0;
            for (int i = 0; i < cadenaBinariaDeArchivo.Length; i=i+8)
            {

                TxtTramaBinario.Text += cadenaBinariaDeArchivo.Substring(i, 8)+"  ";
                cont++;
                if (cont % 12 == 0)
                {
                    TxtTramaBinario.Text += "\r\n";
                }
                
            }

            //Obtenemos la trama convertida a Hexadecimal
            tramaHexadecimal = CadenaBinariaACadenaHexadecimal(cadenaBinariaDeArchivo);
            //Mostramos la trama en pantalla
            cont = 0;string auxcomplemento = "";
            
            for (int i = 0; i < tramaHexadecimal.Length; i=i+2)
            {
                TxtHexa.Text += tramaHexadecimal.Substring(i, 2)+"  ";
                
                cont++;
                if (cont % 12 == 0)
                {
                    TxtHexa.Text += Environment.NewLine;
                }
                //Aqui toma los bits para el checksum IP
                if(cont>=15 && cont <= 34)
                {
                    auxcomplemento += tramaHexadecimal.Substring(i, 2);
                }

                
            }
            //MessageBox.Show(auxcomplemento);
            int sum = 0; int maximo = 0; cont = 0;
            string ultimo = "",sumcomplemento="";

            //PRUEBAS:::::::::::::::::::::::::::::::
            for (int i = 0; i < auxcomplemento.Length; i = i + 4)
            {
                maximo += 65535;
                cont++;
                if (cont != 6)
                {
                    sum += (65535 - Convert.ToInt32(auxcomplemento.Substring(i, 4), 16));
                    sumcomplemento += (65535 - Convert.ToInt32(auxcomplemento.Substring(i, 4), 16)).ToString() + " + ";
                }
                else
                {
                   // MessageBox.Show(auxcomplemento.Substring(i, 4));
                }
                ultimo += auxcomplemento.Substring(i, 4)+" ";
                
            }
            //MessageBox.Show("Cabecera: "+ultimo+ "\nSumatoria Explícita: "+sumcomplemento+"\n Sumatoria de complementos: " + sum.ToString()+"\nChecksum supuesto 3223: "+ Convert.ToInt32("3223", 16) + "\nTotal: "+(maximo-sum).ToString());
            //::::::::::::::::::::::::::::::::::::FIN

            //Obtenemos la direccion Destino y Origen de la trama
            direccionDestino = ObtenerDireccion(tramaHexadecimal, "destino");
            direccionOrigen = ObtenerDireccion(tramaHexadecimal, "origen");
            //Extraemos el tipo de servicio de la trama
            tipoServicio = ObtenerTipoServicio(tramaHexadecimal);
            //--------------------------COMIENZA ANALISIS DE DATOS DE LA TRAMA-----------------------
            informacion = "";
            switch (tipoServicio)
            {
                case "IPv4"://Analisis de Trama IPV4
                    informacion=ObtenerIPInfo(tramaHexadecimal, cadenaBinariaDeArchivo);
                    break;
                //Siguientes Analisis de Tramas
                default://Opcion aun no desarrollada
                    MessageBox.Show("Etapa en desarrollo.", "Atención", MessageBoxButtons.OK);
                    break;
            }
            if (!servicioEncapsulado.Equals(""))
            {
                tipoServicio += " / " + servicioEncapsulado;
            }
            
            //:::::::::::::::::::::::::::AGREGAMOS LA INFORMACION AL DATA GRID VIEW:::::::::::::::::::::::::::::::::::::::::::::::
            DataGridTrama.Rows.Add(direccionDestino, direccionOrigen, tipoServicio, informacion,Posiciones,Ncaracteres);
            
            //Después de terminar todos los procedimientos desactivo el botón
            BtnAnalizarTrama.Enabled = false;
        }

        public string CadenaBinariaACadenaHexadecimal(string cadenaBinaria)
        {
            StringBuilder conversionAHexadecimal = new StringBuilder(cadenaBinaria.Length / 8 + 1);

            int mod4Len = cadenaBinaria.Length % 8;

            //Checamos si el residuo de la longitud de la cadena es diferente de cero
            if (mod4Len != 0)
                // Completa la cadena con 0's a la izquierda para que sea de 8 en 8
                cadenaBinaria = cadenaBinaria.PadLeft(((cadenaBinaria.Length / 8) + 1) * 8, '0');

            for (int i = 0; i < cadenaBinaria.Length; i += 8)
            {
                string ochoBits = cadenaBinaria.Substring(i, 8);
                conversionAHexadecimal.AppendFormat("{0:X2}", Convert.ToByte(ochoBits, 2));
            }

            //El resultado es en bytes, si falta una letra (4 bits) para completar el byte, agrega 0 a la izquierda
            return conversionAHexadecimal.ToString();
        }

        public string ObtenerDireccion(string trama, string tipoOrigen)
        {
            string direccion="";
            if(tipoOrigen == "destino")
            {
                for( int i = 0; i < 12; i++)
                {
                    direccion += trama[i];
                    if((i+1)%2==0 && i != 11)
                    {
                        direccion += ":";
                    }
                }
                
                return direccion;
            }
            else
            {
                //Obtenemos dirección origen
                for (int i = 0; i < 12; i++)
                {
                    direccion += trama[i];
                    if ((i + 1) % 2 == 0 && i != 11)
                    {
                        direccion += ":";
                    }
                }
                return direccion;
            }
        }

        public string ObtenerTipoServicio(string trama)
        {
            string tipoHexadecimal;
            tipoHexadecimal = trama.Substring(24,4);
            switch (tipoHexadecimal)
            {
                case "0800":
                    return "IPv4";
                //Aquí deberían ir todos los posibles casos de tipos de servicio (0x0806, 0x0842, 0x22F3, etc.)
                default:
                    MessageBox.Show("Se introdujo un protocolo diferente a los codificados", "Atención", MessageBoxButtons.OK);
                    break;
            }
            return tipoHexadecimal;
        }

        //:::::::::::::::::::::::::::::::::::::::TRAMA IPV4:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        public string ObtenerIPInfo(string trama, string cadenaBinaria)
        {
            string info = "";//Variable a retornar
            //Variables para el analsis de la trama IP
            string version, precedence, tos, banderas, protocolo, dirIPorigen, dirIPdestino, auxDireccionOrigen
                , auxDireccionDestino;
            int longitud, longitudTotal, desplazamiento, tiempoVida, checksum;

            //-----------------------------VERSION Y LONGITUD--------------------------------------
            version = "Versión: v" + trama.Substring(28, 1);
            info = "";
            longitud = Convert.ToInt32(trama.Substring(28, 1), 16) * Convert.ToInt32(trama.Substring(29, 1), 16);
            info += version  + " Longitud:" + trama.Substring(28, 1) + " x " + trama.Substring(29, 1) + " = " + Convert.ToString(longitud) + " Bytes~";
            Posiciones += ((28 * 2)+1)+",";
            Ncaracteres += "2,";

            //-----------------------------TIPO DE SERVICIO----------------------------------------
            //Obtenemos el equivalente a binario 
            string auxbinario = Convert.ToString(Convert.ToInt32(trama.Substring(30, 2), 16), 2);
            if (auxbinario.Length < 8)
            {
                do
                {
                    auxbinario = "0" + auxbinario;
                } while (auxbinario.Length < 8);

            }
            //Precedence
            precedence = "";
            switch (auxbinario.Substring(0, 3))
            {
                case "000":
                    precedence = "Rutina";
                    break;
                case "001":
                    precedence = "Prioridad";
                    break;
                case "010":
                    precedence = "Inmediato";
                    break;
                case "011":
                    precedence = "Flash";
                    break;
                case "100":
                    precedence = "Flash override";
                    break;
                case "101":
                    precedence = "Crítico";
                    break;
                case "110":
                    precedence = "Internetwork control";
                    break;
                case "111":
                    precedence = "Network control";
                    break;
            }
            //TOS
            tos = "";
            switch (auxbinario.Substring(3, 4))
            {
                case "1000":
                    tos = "Minimizar retardo";
                    break;
                case "0100":
                    tos = "Maximizar la densidad de flujo";
                    break;
                case "0010":
                    tos = "Maximizar la fiabilidad ";
                    break;
                case "0001":
                    tos = "Minimizar el coste monetario";
                    break;
                case "0000":
                    tos = "Servicio normal";
                    break;
            }
            info += " Tipo de servicio: " + precedence + " para: " + tos + "~";
            Posiciones += ((30 * 2) + 1) + ",";
            Ncaracteres += "2,";

            //---------------------------LONGITUD TOTAL DEL PAQUETE------------------------
            int c = 3;
            longitudTotal = 0;
            for (int i = 32; i < 36; i++)
            {
                longitudTotal += Convert.ToInt32(Convert.ToInt32(trama.Substring(i, 1)) * Math.Pow(16, c));
                c--;
            }
            info += " Longitud Total: " + Convert.ToString(longitudTotal) + " Bytes~";
            Posiciones += ((32 * 2) + 1) + ",";
            Ncaracteres += "6,";

            //----------------------------IDENTIFICACION-----------------------------------
            info += " Identificación: " + trama.Substring(36, 4) + " Hex~";
            Posiciones += ((36 * 2) + 1) + ",";
            Ncaracteres += "6,";

            //----------------------------BANDERAS Y VENTANA DESLIZANTE--------------------
            auxbinario = Convert.ToString(Convert.ToInt32(trama.Substring(40, 4), 16), 2);
            if (auxbinario.Length < 16)
            {
                do
                {
                    auxbinario = "0" + auxbinario;
                } while (auxbinario.Length < 16);
            }
            banderas = "";
            switch (auxbinario.Substring(1, 1)) {
                case "1":
                    banderas += ", No fragmentar";
                    break;
                case "0":
                    banderas += ", Si fragmentado";
                    break;
            }
            switch (auxbinario.Substring(2, 1))
            {
                case "1":
                    banderas += ", hay mas fragmentos";
                    break;
                case "0":
                    banderas += ", Último fragmento";
                    break;
            }
            info += " Banderas: " + banderas + " ~";
            Posiciones += ((40 * 2) + 1) + ",";
            Ncaracteres += "2,";
            //---------------------------DESPLAZAMIENTO------------------------------------
            desplazamiento = 0;
            c = 12;
            for (int i = 3; i < 16; i++)
            {
                desplazamiento += Convert.ToInt32(Convert.ToInt32(auxbinario.Substring(i, 1)) * Math.Pow(2, c));
                c--;
            }
            info += " Desplazamiento de la fragmentación: " + Convert.ToString(desplazamiento) + " Bloques de 64 Bits~";
            Posiciones += ((42 * 2) + 1) + ",";
            Ncaracteres += "2,";

            //----------------------------TIEMPO DE VIDA-----------------------------------
            tiempoVida = Convert.ToInt32(trama.Substring(44, 2),16);
            info += " Tiempo de vida: " + tiempoVida + " segundos ~";
            Posiciones += ((44 * 2) + 1) + ",";
            Ncaracteres += "2,";

            //---------------------------------PROTOCOLO-----------------------------------
            string protocoloName = "";
            protocolo = trama.Substring(46, 2);
            switch (protocolo)
            {
                case "06":
                    info += " Protocolo: TCP ~";
                    protocoloName = "TCP";
                    break;

                //Aquí van los demás casos para los distintos protocolos

                default:
                    MessageBox.Show("Etapa en desarrollo.", "Atención", MessageBoxButtons.OK);
                    break;
            }
            servicioEncapsulado = protocoloName;
            Posiciones += ((46 * 2) + 1) + ",";
            Ncaracteres += "2,";
            //---------------------------------CHECKSUM------------------------------------
            string bitsDeChecksum = cadenaBinaria.Substring(112, 272), stringPalabraComplementoA1; //Todos los bits que se debe analizar del checksum
            List<string> palabrasDe16Bits = new List<string>();
            char[] arrayPalabraComplementoA1 = new char[16];
            int x=0, checksumInt=0;
            bool primer1 = false;
            int[] arrayint = new int[10];
            int y = 0;
            for (int i = 0; i < 160; i+=16)
            {
                palabrasDe16Bits.Add(bitsDeChecksum.Substring(i,16));
            }

            foreach (string palabra in palabrasDe16Bits)
            {
                primer1 = false;
                x = 0;
                foreach (char bit in palabra)
                {
                    if (primer1)
                    {
                        if (bit == '1')
                        {
                            arrayPalabraComplementoA1[x] = '0';
                        }
                        else
                            arrayPalabraComplementoA1[x] = '1';
                    }
                    else
                    {
                        if (bit == '1')
                        {
                            primer1 = true;
                            arrayPalabraComplementoA1[x] = '0';
                        }
                        else
                        {
                            arrayPalabraComplementoA1[x] = 'c'; //Caracter para no hacer valer 1 cuando una palabra empieza en 0's
                        }
                    }                        
                    x++;
                }
                stringPalabraComplementoA1 = new string(arrayPalabraComplementoA1);
                stringPalabraComplementoA1 = stringPalabraComplementoA1.Replace("c", "");
                if (stringPalabraComplementoA1 != "00110111011100")
                {
                    arrayint[y] = Convert.ToInt32(stringPalabraComplementoA1, 2);
                    checksumInt += Convert.ToInt32(stringPalabraComplementoA1, 2); //Falta a esto de aquí sacarle complemento a 1      Da en int: 112284   En complemento a 1: 18787 en lugar de 12835

                }
                y++;                
            }

            checksum = Convert.ToInt32(trama.Substring(48, 4), 16);
            info += " Checksum: " + checksum.ToString() + "~";
            Posiciones += ((48 * 2) + 2) + ",";
            Ncaracteres += "6,";

            //-----------------------Dirección IP ORIGEN Y DESTINO------------------------
            auxDireccionOrigen = "";
            auxDireccionDestino = "";
            dirIPorigen = trama.Substring(52, 8); //IP en hexadecimal
            dirIPdestino = trama.Substring(60, 8); //IP en hexadecimal
            for (int i = 0; i < 7; i += 2)
            {
                auxDireccionOrigen += Convert.ToInt32(dirIPorigen.Substring(i, 2), 16).ToString();
                if (i != 6) //porque son 
                    auxDireccionOrigen += "."; //IP en decimal

                auxDireccionDestino += Convert.ToInt32(dirIPdestino.Substring(i, 2), 16).ToString();
                if (i != 6)
                {
                    auxDireccionDestino += ".";
                }
            }
            info += " Dirección IP Origen: " + auxDireccionOrigen + "~";
            info += " Dirección IP Destino: " + auxDireccionDestino + "~";
            Posiciones += ((52 * 2) + 2) + ",";
            Ncaracteres += "14,";
            Posiciones += ((60 * 2) + 2) + ",";
            Ncaracteres += "14,";
            

            //*******************SEGUIMOS CON EL PROTOCOLO DENTRO DE IP**************************************
            
            switch (protocoloName)
            {
                case "TCP":
                    info += ObtenerTCPInfo(trama);
                    break;

                //Aquí van los demás casos para los distintos protocolos

                default:
                    MessageBox.Show("Etapa en desarrollo.", "Atención", MessageBoxButtons.OK);
                    break;
            }
            return info;
        }

        public string ObtenerTCPInfo(string trama)
        {
            string info = "", direccionPuerto, numeroAuxiliar;
            int posicionInsertarns,posicionInsertarnc;
            //-------------------------------DIRECCION DE PUERTO ORIGEN-------------------------------------
            direccionPuerto = Convert.ToInt32(trama.Substring(68,4), 16).ToString();
            //Funcion para traer el puerto
            info += "Dirección de puerto Origen: "+ direccionPuerto+ ObtenerPuertos(Convert.ToInt32(direccionPuerto))+ "~";
            Posiciones += ((68 * 2) + 2) + ",";
            Ncaracteres += "6,";
            //-------------------------------DIRECCION DE PUERTO DESTINO------------------------------------
            direccionPuerto = Convert.ToInt32(trama.Substring(72, 4), 16).ToString();
            //Funcion para traer el puerto
            info += "Dirección de puerto Destino: " + direccionPuerto + ObtenerPuertos(Convert.ToInt32(direccionPuerto)) + "~";
            Posiciones += ((72 * 2) + 3) + ",";
            Ncaracteres += "6,";
            //-------------------------------NUMERO DE SECUENCIA------------------------------------
            numeroAuxiliar = Convert.ToInt32(trama.Substring(76, 8), 16).ToString();
            info += "Número de secuencia: " + numeroAuxiliar;
            //posicionInsertarns = info.Length;
            info += "~";
            Posiciones += ((76 * 2) + 3) + ",";
            Ncaracteres += "14,";
            //-------------------------------NUMERO DE CONFIRMACION------------------------------------
            numeroAuxiliar = Convert.ToInt32(trama.Substring(84, 8), 16).ToString();
            info += "Número de confirmación: " + numeroAuxiliar;
            //posicionInsertarnc = info.Length;
            info += "~";
            Posiciones += ((84 * 2) + 3) + ",";
            Ncaracteres += "14,";
            //-------------------------------LONGITUD DE CABECERA------------------------------------
            info += "Longitud de la cabecera: " + Convert.ToInt32(trama.Substring(92, 1), 16).ToString() + " palabras de 32 Bits~";
            Posiciones += ((92 * 2) + 3) + ",";
            Ncaracteres += "2,";
            //-------------------------------BANDERAS------------------------------------------------
            info += "Banderas: ";
            //Algoritmo de banderas...
            bool urg = false;
            string auxbinario = Convert.ToString(Convert.ToInt32(trama.Substring(94, 2), 16), 2);
            if (auxbinario.Length < 6)
            {
                do
                {
                    auxbinario = "0" + auxbinario;
                } while (auxbinario.Length < 6);
            }
            //URG
            if(auxbinario.Substring(0, 1).Equals("1"))
            {
                info += "1=URG";
                urg = true;
            }
            else
            {
                info += "0";
            }
            //ACK
            if (auxbinario.Substring(1, 1).Equals("1"))
            {
                info += ", 1=ACK";
                //El numero de confirmacion CONTIENE EL VALOR DEL SIGUIENTE NÚMERO DE SECUENCIA QUE SE ESPERA RECIBIR
                posicionInsertarnc = info.IndexOf("Número de confirmación: ") + 24;
                info = info.Insert(posicionInsertarnc, "(ACK, valor del siguiente numero de secuencia a recibir) ");
            }
            else
            {
                info += ", 0";
            }
            //PSH
            if (auxbinario.Substring(2, 1).Equals("1"))
            {
                info += ", 1=PUSH";
            }
            else
            {
                info += ", 0";
            }
            //RST
            if (auxbinario.Substring(3, 1).Equals("1"))
            {
                info += ", 1=RST";
            }
            else
            {
                info += ", 0";
            }
            //SYN
            if (auxbinario.Substring(4, 1).Equals("1"))
            {
                info += ", 1=SYN";
                //SI EL BYTE DE CONTROL SYN ESTÁ A 1, EL NÚMERO DE SECUENCIA ES EL INICIAL(N) Y EL PRIMER BYTE DE DATOS SERÁ EL N+1.
                posicionInsertarns = info.IndexOf("Número de secuencia: ") + 21;
                info = info.Insert(posicionInsertarns, "(SYN, Número de secuencia inicial) ");
            }
            else
            {
                info += ", 0";
            }
            //FIN
            if (auxbinario.Substring(5, 1).Equals("1"))
            {
                info += ", 1=FIN";
            }
            else
            {
                info += ", 0";
            }

            info += "~";
            Posiciones += ((94 * 2) + 3) + ",";
            Ncaracteres += "2,";
            //-------------------------------TAMAÑO DE LA VENTANA------------------------------------
            //WIKIPEDIA******
            //especifica el número máximo de bytes que pueden ser metidos en el buffer de recepción o dicho de otro modo
            info += "Tamaño de la ventana: " + Convert.ToInt32(trama.Substring(96, 4), 16).ToString() + " bytes~";
            Posiciones += ((96 * 2) + 4) + ",";
            Ncaracteres += "6,";
            //-------------------------------CHECKSUM------------------------------------------------
            numeroAuxiliar = Convert.ToInt32(trama.Substring(100, 4), 16).ToString();
            info += "Checksum: " + numeroAuxiliar + "~";
            Posiciones += ((100 * 2) + 4) + ",";
            Ncaracteres += "6,";
            //-------------------------------PUNTERO URGENTE------------------------------------------------
            //WIKIPEDIA*******
            //Cantidad de bytes desde el número de secuencia que indica el lugar donde acaban los datos urgentes
            info += "Puntero Urgente: " + Convert.ToInt32(trama.Substring(104, 4), 16).ToString() + " bytes desde el número de secuencia~";
            Posiciones += ((104 * 2) + 4) + ",";
            Ncaracteres += "6,";
            //-------------------------------OPCIONES Y RELLENO------------------------------------------------
            info += "Relleno u opciones: " + trama.Substring(108, 6) + "Hex~";
            Posiciones += ((108 * 2) + 4) + ",";
            Ncaracteres += "10,";


            return info;
        }

        public string ObtenerPuertos(int puerto)
        {
            string nomPuerto = "=";

            switch (puerto)
            {
                case 139:
                    nomPuerto += "NETBIOS Session Service";
                    break;
                case 1031:
                    nomPuerto += "Reservado";
                    break;
                default:
                    nomPuerto += "En desarrollo";
                    break;
            }

            if(puerto>=0 && puerto <= 1023)
            {
                nomPuerto += ", puerto bien conocido";
            }
            else if(puerto>=1024 && puerto<= 49151)
            {
                nomPuerto += ", puerto registrado";
            }
            else
            {
                nomPuerto += ", puerto dinamico";
            }

                return nomPuerto;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();           
        }

        private void DataGridTrama_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        //:::::::::::::::::::::::::::::::::::::::::::MOSTRAMOS LOS DETALLES DEL PAQUETE SELECCIONADO:::::::::::::::::::::::::::::::
        private void DataGridTrama_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            string[] elementosSplit, elementosPosicion, elementosNcaracteres;

            try
            {
                //Leemos la fila seleccionada
                DataGridViewRow selectedRow = DataGridTrama.Rows[index];
                //Leemos el dato de informacion, numero de caracteres y posiciones
                string informacionTrama = selectedRow.Cells[3].Value.ToString();
                string posicionesTrama = selectedRow.Cells[4].Value.ToString();
                string caracteresTrama = selectedRow.Cells[5].Value.ToString();
                //Agregamos al DGV de la informacion

                elementosSplit = informacionTrama.Split('~');
                elementosPosicion = posicionesTrama.Split(',');
                elementosNcaracteres = caracteresTrama.Split(',');
                int indice = 0;
                foreach (string elemento in elementosSplit)
                {
                    DGVdetalles.Rows.Add(elemento, elementosPosicion[indice], elementosNcaracteres[indice]);
                    indice++;
                }

                //Seleccionamos
                //Limpiamos la seleccion anterior
                TxtHexa.SelectAll();
                TxtHexa.SelectionBackColor = Color.White;
                TxtHexa.SelectionFont = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);

                //Seleccionamos lo nuevo
                TxtHexa.Select(0, 57);
                TxtHexa.SelectionBackColor = Color.LightSkyBlue;
                TxtHexa.SelectionFont = new Font("Microsoft Sans Serif", 11, FontStyle.Italic);

            }
            catch { }
            
        }

        //::::::::::::::::::::::::::::::::::::::SELECCIONAMOS EL CAMPO EN EL FLUJO DE DATOS:::::::::::::::::::::::::::::::::::::::::
        private void DGVdetalles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            try
            {
                //Leemos la fila seleccionada
                DataGridViewRow selectedRow = DGVdetalles.Rows[index];
                //MessageBox.Show(selectedRow.Cells[1].Value.ToString() + "\n" + selectedRow.Cells[2].Value.ToString());
                int pos = Convert.ToInt32(selectedRow.Cells[1].Value.ToString());
                int car = Convert.ToInt32(selectedRow.Cells[2].Value.ToString());

                //Limpiamos la seleccion anterior
                TxtHexa.SelectAll();
                TxtHexa.SelectionBackColor = Color.White;
                TxtHexa.SelectionFont = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);

                //Seleccionamos lo nuevo
                TxtHexa.Select(pos, car);
                TxtHexa.SelectionBackColor = Color.Orange;
                TxtHexa.SelectionFont = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            }
            catch { }
            
        }

        private void DGVdetalles_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void DGVdetalles_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            try
            {
                //Leemos la fila seleccionada
                DataGridViewRow selectedRow = DGVdetalles.Rows[index];
                //MessageBox.Show(selectedRow.Cells[1].Value.ToString() + "\n" + selectedRow.Cells[2].Value.ToString());
                int pos = Convert.ToInt32(selectedRow.Cells[1].Value.ToString());
                int car = Convert.ToInt32(selectedRow.Cells[2].Value.ToString());

                //Limpiamos la seleccion anterior
                TxtHexa.SelectAll();
                TxtHexa.SelectionBackColor = Color.White;
                TxtHexa.SelectionFont = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);

                //Seleccionamos lo nuevo
                TxtHexa.Select(pos, car);
                TxtHexa.SelectionBackColor = Color.Orange;
                TxtHexa.SelectionFont = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            }
            catch { }
        }
    }
}
