using System;

Console.WriteLine("====================================");
Console.WriteLine("     COOPERATIVA AHORRO SEGURO");
Console.WriteLine("====================================");

int opcionPrincipal;

do
{
    Console.WriteLine("\n========== MENU PRINCIPAL ==========");
    Console.WriteLine("1. Ejercicio 1 - Cajero automatico");
    Console.WriteLine("2. Ejercicio 2 - Simulador de prestamos");
    Console.WriteLine("3. Salir");
    Console.Write("Seleccione una opcion: ");

    while (!int.TryParse(Console.ReadLine(), out opcionPrincipal) ||
           opcionPrincipal < 1 || opcionPrincipal > 3)
    {
        Console.Write("Opcion invalida. Escriba 1, 2 o 3: ");
    }

    switch (opcionPrincipal)
    {
        case 1:

            // EJERCICIO 1: CAJERO AUTOMATICO

            string pinCorrecto = "1234";
            int intentos = 0;
            bool acceso = false;

            while (intentos < 3 && !acceso)
            {
                Console.Write("\nIngrese su PIN de cuatro digitos: ");
                string pinIngresado = Console.ReadLine() ?? "";

                if (pinIngresado == pinCorrecto)
                {
                    acceso = true;
                    Console.WriteLine("Acceso correcto.");
                }
                else
                {
                    intentos++;
                    Console.WriteLine("PIN incorrecto. Intentos restantes: " + (3 - intentos));
                }
            }

            if (!acceso)
            {
                Console.WriteLine("Cuenta bloqueada por seguridad.");
            }
            else
            {
                decimal saldo = 10000m;
                int cantidadDepositos = 0;
                int cantidadRetiros = 0;
                int opcionCajero;

                do
                {
                    Console.WriteLine("\n========== CAJERO AUTOMATICO ==========");
                    Console.WriteLine("1. Consultar saldo");
                    Console.WriteLine("2. Depositar dinero");
                    Console.WriteLine("3. Retirar dinero");
                    Console.WriteLine("4. Salir");
                    Console.Write("Seleccione una opcion: ");

                    while (!int.TryParse(Console.ReadLine(), out opcionCajero) ||
                           opcionCajero < 1 || opcionCajero > 4)
                    {
                        Console.Write("Opcion invalida. Seleccione del 1 al 4: ");
                    }

                    switch (opcionCajero)
                    {
                        case 1:
                            Console.WriteLine("Su saldo actual es: RD$" + saldo);
                            break;

                        case 2:
                            decimal deposito;

                            Console.Write("Ingrese el monto a depositar: RD$");

                            while (!decimal.TryParse(Console.ReadLine(), out deposito) || deposito <= 0)
                            {
                                Console.Write("Monto invalido. Ingrese una cantidad mayor que cero: RD$");
                            }

                            saldo += deposito;
                            cantidadDepositos++;

                            Console.WriteLine("Deposito realizado correctamente.");
                            Console.WriteLine("Nuevo saldo: RD$" + saldo);
                            break;

                        case 3:
                            decimal retiro;

                            Console.Write("Ingrese el monto a retirar: RD$");

                            while (!decimal.TryParse(Console.ReadLine(), out retiro) ||
                                   retiro <= 0 || retiro > saldo || retiro % 100 != 0)
                            {
                                Console.WriteLine("Monto invalido.");
                                Console.WriteLine("Debe ser mayor que cero, no superar el saldo y ser multiplo de RD$100.");
                                Console.Write("Ingrese nuevamente el monto: RD$");
                            }

                            saldo -= retiro;
                            cantidadRetiros++;

                            Console.WriteLine("Retiro realizado correctamente.");
                            Console.WriteLine("Nuevo saldo: RD$" + saldo);
                            break;

                        case 4:
                            Console.WriteLine("\nResumen de la cuenta:");
                            Console.WriteLine("Cantidad de depositos: " + cantidadDepositos);
                            Console.WriteLine("Cantidad de retiros: " + cantidadRetiros);
                            Console.WriteLine("Saldo final: RD$" + saldo);
                            Console.WriteLine("Gracias por utilizar nuestros servicios.");
                            break;
                    }

                } while (opcionCajero != 4);
            }

            break;

        case 2:

            // EJERCICIO 2: SIMULADOR DE PRESTAMOS

            string repetirPrestamo;

            do
            {
                decimal monto;

                Console.WriteLine("\n========== SIMULADOR DE PRESTAMOS ==========");

                Console.Write("Ingrese el monto del prestamo (RD$5,000 - RD$500,000): RD$");

                while (!decimal.TryParse(Console.ReadLine(), out monto) ||
                       monto < 5000 || monto > 500000)
                {
                    Console.Write("Monto invalido. Ingrese entre RD$5,000 y RD$500,000: RD$");
                }

                int meses;

                Console.Write("Ingrese el plazo en meses (6 - 60): ");

                while (!int.TryParse(Console.ReadLine(), out meses) ||
                       meses < 6 || meses > 60)
                {
                    Console.Write("Plazo invalido. Ingrese entre 6 y 60 meses: ");
                }

                string categoria;
                decimal tasaAnual = 0;

                Console.WriteLine("\nCategorias de socios:");
                Console.WriteLine("A. Categoria A - 12%");
                Console.WriteLine("B. Categoria B - 15%");
                Console.WriteLine("C. Categoria C - 18%");
                Console.Write("Seleccione su categoria: ");

                categoria = (Console.ReadLine() ?? "").ToUpper();

                while (categoria != "A" && categoria != "B" && categoria != "C")
                {
                    Console.Write("Categoria invalida. Escriba A, B o C: ");
                    categoria = (Console.ReadLine() ?? "").ToUpper();
                }

                if (categoria == "A")
                {
                    tasaAnual = 0.12m;
                }
                else if (categoria == "B")
                {
                    tasaAnual = 0.15m;
                }
                else
                {
                    tasaAnual = 0.18m;
                }

                decimal tasaMensual = tasaAnual / 12;

                double potencia = Math.Pow((double)(1 + tasaMensual), meses);

                decimal cuota = monto * (decimal)(
                    (double)tasaMensual * potencia / (potencia - 1)
                );

                cuota = Math.Round(cuota, 2);

                Console.WriteLine("\n========== RESULTADO DEL PRESTAMO ==========");
                Console.WriteLine("Monto solicitado: RD$" + monto);
                Console.WriteLine("Categoria: " + categoria);
                Console.WriteLine("Tasa anual: " + (tasaAnual * 100) + "%");
                Console.WriteLine("Plazo: " + meses + " meses");
                Console.WriteLine("Cuota mensual: RD$" + cuota);

                decimal saldoPendiente = monto;
                decimal totalPagado = 0;
                decimal totalIntereses = 0;

                Console.WriteLine("\n========== TABLA DE AMORTIZACION ==========");
                Console.WriteLine("Mes | Cuota | Interes | Capital | Saldo");

                for (int mes = 1; mes <= meses; mes++)
                {
                    decimal interes = Math.Round(saldoPendiente * tasaMensual, 2);
                    decimal abonoCapital = cuota - interes;

                    if (abonoCapital > saldoPendiente)
                    {
                        abonoCapital = saldoPendiente;
                    }

                    decimal pagoReal = abonoCapital + interes;

                    saldoPendiente -= abonoCapital;
                    totalPagado += pagoReal;
                    totalIntereses += interes;

                    if (saldoPendiente < 0.01m)
                    {
                        saldoPendiente = 0;
                    }

                    Console.WriteLine(
                        mes + " | RD$" + pagoReal +
                        " | RD$" + interes +
                        " | RD$" + abonoCapital +
                        " | RD$" + saldoPendiente
                    );
                }

                Console.WriteLine("\n========== RESUMEN FINAL ==========");
                Console.WriteLine("Total pagado: RD$" + totalPagado);
                Console.WriteLine("Total de intereses: RD$" + totalIntereses);
                Console.WriteLine("Saldo pendiente: RD$" + saldoPendiente);

                Console.Write("\n¿Desea simular otro prestamo? (S/N): ");
                repetirPrestamo = (Console.ReadLine() ?? "").ToUpper();

                while (repetirPrestamo != "S" && repetirPrestamo != "N")
                {
                    Console.Write("Respuesta invalida. Escriba S o N: ");
                    repetirPrestamo = (Console.ReadLine() ?? "").ToUpper();
                }

            } while (repetirPrestamo == "S");

            break;

        case 3:
            Console.WriteLine("\nGracias por utilizar Cooperativa Ahorro Seguro.");
            break;
    }

} while (opcionPrincipal != 3);