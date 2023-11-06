using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLASS
{
    internal class Program
    {



        static void Main(string[] args)
        {
            // Cola para clientes normales
        Queue<Cliente> colaClientesNormales = new Queue<Cliente>();

            // Bicola para clientes VIP (al principio y al final)
            LinkedList<Cliente> bicolaClientesVIP = new LinkedList<Cliente>();

            // Lista para representar la cola de prioridad
            List<Cliente> colaPrioridadClientesUrgentes = new List<Cliente>();

            while (true)
            {
                Console.WriteLine("Ingrese el nombre del cliente (o escriba 'mostrar' para ver la lista, o 'salir' para finalizar):");
                string entrada = Console.ReadLine();

                if (entrada.ToLower() == "salir")
                {
                    break;
                }
                else if (entrada.ToLower() == "mostrar")
                {
                    MostrarClientesAgregados(colaClientesNormales, bicolaClientesVIP, colaPrioridadClientesUrgentes);
                    continue;
                }

                Console.WriteLine("Elija el tipo de cliente (1: Normal, 2: VIP, 3: Urgente):");
                if (int.TryParse(Console.ReadLine(), out int tipoCliente))
                {
                    TipoCliente tipo;
                    switch (tipoCliente)
                    {
                        case 1:
                            tipo = TipoCliente.Normal;
                            break;
                        case 2:
                            tipo = TipoCliente.VIP;
                            break;
                        case 3:
                            tipo = TipoCliente.Urgente;
                            break;
                        default:
                            tipo = TipoCliente.Normal;
                            break;
                    }

                    var nuevoCliente = new Cliente(entrada, tipo);

                    if (tipo == TipoCliente.Normal)
                    {
                        colaClientesNormales.Enqueue(nuevoCliente);
                    }
                    else if (tipo == TipoCliente.VIP)
                    {
                        bicolaClientesVIP.AddLast(nuevoCliente);
                    }
                    else
                    {
                        colaPrioridadClientesUrgentes.Add(nuevoCliente);
                    }

                    Console.WriteLine($"Cliente '{entrada}' ha sido agregado.");
                }
                else
                {
                    Console.WriteLine("Tipo de cliente no válido. Cliente no agregado.");
                }
            }

            // Atención de clientes en el orden correcto
            Console.WriteLine("Atendiendo a los clientes:");
            Console.WriteLine("Clientes Normales:");
            while (colaClientesNormales.Count > 0)
            {
                Console.WriteLine("Atendiendo a " + colaClientesNormales.Dequeue().Nombre);
            }

            Console.WriteLine("Clientes VIP:");
            while (bicolaClientesVIP.Count > 0)
            {
                Console.WriteLine("Atendiendo a " + bicolaClientesVIP.First.Value.Nombre);
                bicolaClientesVIP.RemoveFirst();
            }

            Console.WriteLine("Clientes Urgentes:");
            while (colaPrioridadClientesUrgentes.Count() > 0)
            {
                var urgente = colaPrioridadClientesUrgentes.First();
                Console.WriteLine("Atendiendo a " + urgente.Nombre);
                colaPrioridadClientesUrgentes.Remove(urgente);
            }
        }

        static void MostrarClientesAgregados(Queue<Cliente> normales, LinkedList<Cliente> vip, List<Cliente> urgentes)
        {
            Console.WriteLine("Clientes agregados:");
            Console.WriteLine("Clientes Normales:");
            foreach (var cliente in normales)
            {
                Console.WriteLine($"{cliente.Nombre} (Tipo: Normal)");
            }

            Console.WriteLine();

            Console.WriteLine("Clientes VIP:");
            foreach (var cliente in vip)
            {
                Console.WriteLine($"{cliente.Nombre} (Tipo: VIP)");
            }

            Console.WriteLine();

            Console.WriteLine("Clientes Urgentes:");
            foreach (var cliente in urgentes)
            {
                Console.WriteLine($"{cliente.Nombre} (Tipo: Urgente)");
            }

            Console.WriteLine();
        }
    }

    enum TipoCliente
    {
        Normal = 1,
        VIP = 2,
        Urgente = 3
    }





}


