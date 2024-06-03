Prueba FullStack ALEJANDRA CUESTA ARTEAGA

03/06/2024

Backend: 

- Se crearon tres endpoints para el módulo de Currencies. 
	-/api/Currencies/Get:
	El cual devuelve las monedas disponibles.

	-/api/Currencies/GetByCode/{code}:
	El cual devuelve la información de una moneda específica. 

	-/api/Currencies/AddCurrency:
	El cual permite agregar monedas, solicitando el code, name y rate.

- Se crearon siete endpoints para el módulo de Flight.
	-/api/Flight/Get/{currency}:
	Es el método que obtiene la lista de vuelos y su precio basado en el código de la moneda.

	-/api/Flight/GetAllOrigins:
	Es el método que devuelve todos los origenes de los vuelos.

	-/api/Flight/GetAllDestinations:
	Es el método que devuelve todos los destinos de los vuelos.

	-/api/Flight/GetAll:
	Es el método que devuelve todos los vuelos.

	-/api/Flight/GetByCode/{id}:
	Es el método que devuelve un vuelo específico por ID.

	-/api/Flight/AddFlight:
	Es el método que permite añadir vuelos.

	-/api/Flight/GetJourney/{origin}/{destination}/{currency}:
	Es el método que permite ver el itinerario completo de los vuelos seleccionados por origen, destsino y moneda seleccionada.

- Se crearon tres endpoints para el módulo Transport

	-/api/Transport/Get:
	El cual devuelve las aerolineas disponibles.

	-/api/Transport/GetByCode/{id}:
	El cual devuelve la información de una aerolínea específica. 

	-/api/Transport/AddTransport:
	El cual permite agregar aerolineas y el número de vuelo.

Estos endpoints pueden ser probados con Swagger UI y serán consumidos mediante el FrontEnd. 

FrontEnd

Se realizó una aplicación en Angular, donde se creó un componente para mostrar los resultados del vuelo seleccionado, para ello
se creó un formulario que obtiene los origenes, los destinos y monedas del BackEnd mediante los endoints previamente descritos.

También cuenta con un filtro para seleccionar el tipo de vuelo que se desea adquirir (OneWay o RoundTrip).

Cuando se presiona el botón Search, se envían los datos del formulario al endpoint GetJourney el cuál retorna la información del JSON acorde con los datos enviados. 

Si se selecciona un tipo de vuelo RoundTrip mostrará las opciones de vuelos de regreso, en caso de no hacerlo, únicamente mostrará un itinerario OneWay. 

Los precios cambian dependiendo el tipo de moneda y las escalas que se presenten en cada itinerario, es importante haber agregado las monedas previamente. 

TIEMPO DESTINADO A LA PRUEBA
--3 días--

Con un trabajo diario de aproximadamente 10 horas, se realizó el trabajo del Backend en 2 días y el frontend en un día. 








