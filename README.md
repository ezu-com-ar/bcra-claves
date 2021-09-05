# Ezu.CBU

Este paquete contiene estructuras para trabajar con CBU (Clave Bancaria Uniforme) y CVU (Clave Virtual Uniforme) según la definición del BCRA (Argentina).

[![nuget](https://img.shields.io/nuget/v/Ezu.CBU.svg)](https://www.nuget.org/packages/Ezu.CBU/) ![Argentina](https://www.countryflags.io/ar/flat/16.png)


## Instalación
```
Install-Package Ezu.CBU -Version 0.1.0
```

## Modo de uso
Puede instanciar un CBU o un CVU de las siguientes formas.

### A partir de su valor
```c#
var cbu = new Cbu("0110012920000091344977");
var cvu = new Cvu("0000003100062244154712");
```

### A partir de sus bloques
```c#
var cbu = new Cbu("01100129", "20000091344977");
var cvu = new Cvu("00000031", "00062244154712");
```

### A partir de sus componentes
```c#
var cbu = new Cbu(
    nroEntidad: "011",
    nroSucursal: "0012",
    dvBloque1: "9",
    nroCuenta: "2000009134497",
    dvBloque2: "7");
var cvu = new Cvu(
    nroPsp: "0003",
    dvBloque1: "1",
    idCliente: "006224415471",
    dvBloque2: "2");
```
> Los ceros a la izquierda pueden ser omitidos.

## Métodos

### EsValido()
.EsValido() controla que los componentes del CBU y los dígitos verificadores sean válidos.
```c#
bool cbuEsValido = cbu.EsValido();
bool cvuEsValido = cvu.EsValido();
```
También es posible omitir la verificación de los dígitos verificadores:
```c#
var validador = new CbuValidator { ValidarDvs = false };
bool cbuEsValido = cbu.EsValido(validador);

var validador = new CvuValidator { ValidarDvs = false };
bool cvuEsValido = cvu.EsValido(validador);
```


### ToString()
Puede obtener la expresión del CBU utilizando ToString()
```c#
var cbuStr = cbu.ToString();
// "0110012920000091344977"
var cvuStr = cvu.ToString();
// "0000003100062244154712"
```

### CorregirDvs
Puede corregir los dígitos verificadores de la siguiente forma:
```c#
var cbu = new Cbu("0110012X2000009134497X");
var cbuCorregido = cbu.CorregirDvs();
// "0110012920000091344977"

var cvu = new Cbu("0000003X0006224415471X");
var cvuCorregido = cvu.CorregirDvs();
// "0000003100062244154712"
```
> Este método creará un nuevo objeto CBU o CVU, pues los tipos CBU y CVU son inmutables.

## Obtención de componentes (Parseo)
```c#
var cbu = new Cbu("0110012920000091344977");
var nroEntidad = cbu.NroEntidad; // "011"
var nroSucursal = cbu.NroSucursal; // "0012"
var dvBloque1 = cbu.DvBloque1; // "9"
var nroCuenta = cbu.NroCuenta; // "2000009134497"
var dvBloque2 = cbu.DvBloque2; // "7"

var cvu = new Cvu("0000003100062244154712");
var indicacionCvu = cvu.IndicacionCvu; // "000"
var nroPsp = cvu.NroPsp; // "0003"
var dvBloque1 = cvu.DvBloque1; // "1"
var reservado = cvu.Reservado; // "0"
var idCliente = cvu.IdCliente; // "006224415471"
var dvBloque2 = cvu.DvBloque2; // "2"
```

## Generación de CBUs
Puede generar CBUs válidos utilizando el generador de CBUs. 
```c#
const int seed = 123;
var cbuGenerator = new CbuGenerator(seed);
var cbu1 = cbuGenerator.Next(); // "9839077100007435455173"
var cbu2 = cbuGenerator.Next(); // "8117387700000483150175"
var cvuGenerator = new CvuGenerator(seed);
var cvu1 = cvuGenerator.Next(); // "0009844700009078153229"
var cvu2 = cvuGenerator.Next(); // "0007434400008116416520"
```

## Referencias:
- [Clave Bancaria Uniforme](https://es.wikipedia.org/wiki/Clave_Bancaria_Uniforme)

- [Clave Virtual Uniforme](http://www.bcra.gov.ar/pdfs/sistemasfinancierosydepagos/SNP3518.pdf)
