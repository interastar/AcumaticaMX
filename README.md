AcumaticaMX
===========
v1.0 Homologación de campos contables para México
Paquete de Acumatica para estandarización de datos en México

| **Versión de Acumatica** | +5.3 | **Autor** | Marco Villaseñor |
| --- | --- | --- | --- |
| **Versión del Documento** | 1.0 | **Fecha** | 15 de julio 2016 |

## Contenido
1. [Información del Documento](#información-del-documento)
2. [Introducción](introduccion)
3. [Alcance](alcance)
4. [Referencias](referencias)
5. [Información Fiscal General de Personas](información-fiscal-general-de-personas)
6. [Registro Federal de Contribuyentes](registro-federal-de-contribuyentes)
7. [Nombre de Persona Moral](nombre-de-persona-moral)
8. [Nombre de Persona Física](nombre-de-persona-física)
9. [Dirección Fiscal](direccion-fiscal)
10. [Información de Documentos Fiscales](información-de-documentos-fiscales)
11. [CFDI - CxC](cfdi---cxc)
12. [CFDI - CxP](cfdi---cxp)

## Información del Documento
**Versiones del Documento**

| **Versión** | **Fecha** | **Descripción** |
| --- | --- | --- |
| 1.0 | 15.07.2016 | Versión inicial |

## Introducción
Este documento busca ser una referencia estándar para partners de Acumatica que deseen desarrollar módulos que cumplan con normas de contabilidad en México. El objetivo principal es evitar duplicidad de información, minimizar conflictos y garantizar la compatibilidad de módulos que sigan los lineamientos descritos en este documento.

## Alcance
Este documento especifica los modelos y campos considerados para almacenar la información requerida por distintas normas del SAT.

Dentro de las definiciones se identifican los modelos y campos existentes en el Framework así como los nuevos campos a crear para almacenar información que no tiene una correspondencia directa con un campo existente.

No se incluyen ejemplos de código. Las recomendaciones sólo cubren los campos definidos y siguen las prácticas recomendadas por Acumatica para desarrollos usando el Framework.

## Criterios de Diseño
Estas definiciones buscan seguir las recomendaciones de Acumatica para el desarrollo de módulos de extensión y tratan de usar los objetos y campos existentes siempre que sea posible.

Cuando sea necesario agregar campos no existentes, se hará por medio de una tabla de extensión nueva para evitar modificar las tablas nativas, aumentar la compatibilidad del módulo y evitar conflictos con otras personalizaciones.

## Referencias
Los siguientes documentos se mencionan en parte dentro del documento o fueron usados como guía para definir los modelos recomendados:

| ID | Nombre | Documento | Autor | Fecha |
| --- | --- | --- | --- | --- |
| 1 | Anexo20RMF2014.doc | ANEXO 20 de la Resolución Miscelánea Fiscal para 2014, publicada el 30 de diciembre de 2013 | SHCP | 17-02-2014 |
| 2 | T300_AcumaticaCustomizationPlatform_5_3.pdf | Acumatica Customization Platform 5.3 | Acumatica | 10-05-2016 |

## Información Fiscal General de Personas

Se refiere a datos utilizados en contabilidad y documentos del SAT relacionados a personas, ya sean físicas o morales.

###Registro Federal de Contribuyentes

| **Atributo** | **Uso** | **DAC (modelo/tabla)** | **Campo** | **Long** | **Descripción** |
| --- | --- | --- | --- | --- | --- |
| **RFC** | Requerido | BAccount | TaxRegistrationID | 13 |   |
| **Regimen** | Requerido | MXBAccountExtension | Regimen | 100 |   |

###Nombre de Persona Moral

| **Atributo** | **Uso** | **DAC (modelo/tabla)** | **Campo** | **Long** | **Descripción** |
| --- | --- | --- | --- | --- | --- |
| **Razón Social** | Requerido | BAccount | FullName | 255 |   |

###Nombre de Persona Física

| **Atributo** | **Uso** | **DAC (modelo/tabla)** | **Campo** | **Long** | **Descripción** |
| --- | --- | --- | --- | --- | --- |
| **Primer nombre** | Requerido | Contact | FirstName | 50 |   |
| **Segundo Nombre** | Requerido | Contact | MiddleName | 50 |   |
| **Apellido Paterno** | Requerido | Contact | LastName | 100 |   |
| **Apellido Materno** | Requerido | MXContactExtension | SecondLastName | 100 |   |

###Curp

| **Atributo** | **Uso** | **DAC (modelo/tabla)** | **Campo** | **Long** | **Descripción** |
| --- | --- | --- | --- | --- | --- |
| **CURP** | Opcional | MXContactExtension | PersonalID | 100 |   |

###Domicilio Fiscal

| **Atributo** | **Uso** | **DAC (modelo/tabla)** | **Campo** | **Long** | **Descripción** |
| --- | --- | --- | --- | --- | --- |
| **Calle** | Requerido | MXAddressExtension | Street | 50 |   |
| **noExterior** | Opcional | MXAddressExtension | ExtNumber | 10 |   |
| **noInterior** | Opcional | MXAddressExtension | IntNumber | 10 |   |
| **colonia** | Opcional | MXAddressExtension | Neighborhood | 50 |   |
| **localidad** | Opcional | Address | City | 50 |   |
| **referencia** | Opcional | MXAddressExtension | Reference | 100 |   |
| **m**** unicipio** | Requerido para sucursal. Opcional para clientes | MXAddressExtension | Municipality | 50 | Municipio o Delegación |
| **estado** | Requerido | Address | State | 50 |   |
| **país** | Requerido | Address | CountryID | 2 |   |
| **codigoPostal** | Requerido | Address | PostalCode | 20 |   |

## Información de Documentos Fiscales

Se refiere a datos utilizados en documentos del SAT que deben asociarse a algún modelo existente en el sistema Acumatica como lo son facturas, notas de cargo, notas de cobro, etc.

###CFDI - CxC

| **Atributo** | **Uso** | **DAC (modelo/tabla)** | **Campo** | **Long** | **Descripción** |
| --- | --- | --- | --- | --- | --- |
| **Folio** | Requerido | ARRegister | RefNbr | 50 |   |
| **Tipo de Documento** | Requerido | ARRegister | DocType |   | Puede ser egreso o ingreso |
| **Fecha** | Requerido | ARRegister | DocDate |   |   |
| **Total** | Requerido | ARRegister | CuryOrigDocAmt |   |   |
| **Cuenta origen transferencia** | Opcional | MXARRegisterExtension | NumCtaPago | 4 |   |
| **Método de Pago** | Requerido | MXARRegisterExtension | PayMethod | 50 |   |
| **Forma de Pago** | Requerido | MXARRegisterExtension | PayForm | 50 |   |
| **Sello CFD** | Requerido | MXARRegisterExtension | CfdStamp | 1000 |   |
| **Número de certificado** | Requerido | MXARRegisterExtension | Certificate | 100 |   |
| **Sello del SAT** | Requerido | MXARRegisterExtension | SatStamp | 1000 |   |
| **UUID** | Requerido | MXARRegisterExtension | Uuid |   |   |
| **Fecha timbrado** | Requerido | MXARRegisterExtension | StampDate |   |   |
| **Cadena Original del timbre fiscal** | Requerido | MXARRegisterExtension | TfdOriginalString | 2500 |   |
| **Código QR** | Requerido | MXARRegisterExtension | QrCode |   |   |
| **Monto en letra** |   | MXARRegisterExtension | AmountText |   | Campo virtual calculado |

###CFDI - CxP (por definir)

| **Atributo** | **Uso** | **DAC (modelo/tabla)** | **Campo** | **Long** | **Descripción** |
| --- | --- | --- | --- | --- | --- |
| **Folio** | Requerido | APRegister | RefNbr | 50 |   |
| **Tipo de Documento** | Requerido | APRegister | DocType |   | Puede ser Egreso o Ingreso |
| **Fecha** | Requerido | APRegister | DocDate |   |   |
| **Total** | Requerido | APRegister | CuryOrigDocAmt |   |   |
| **Método de Pago** |   |   | PayMethod | 50 |   |
| **Forma de Pago** |   |   | PayForm | 50 |   |
| **Sello CFD** | Requerido |   | CfdStamp | 1000 |   |
| **Número de certificado** | Requerido |   | Certificate | 100 |   |
| **Sello del SAT** | Requerido |   | SatStamp | 1000 |   |
| **UUID** | Requerido |   | Uuid |   |   |
