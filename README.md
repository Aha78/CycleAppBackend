

Linkit frontend:n ja backend:n 

https://github.com/Aha78/testsforCycleApp

https://github.com/Aha78/CycleAppBackend

Kaupunkipyörä App

Tehty:
Asemian ja matkojen sivutus
matkoissa tyydytty yli 20000 ms matkoihin, muussa tapaksessa tietojen siirrossa palvelimelle olisi tullut ongelma, tietokantapalvelimeni 
on rajoitettu 64 mt: n tiedonsiirtoon ja siirrettävää olisi ollut kerralla yli 90 mt.

Asemien tiedot-välilehti

Ohjelma on kahdessa osassa, ensiksi on käyttöliittymä(React native) ja sitten on backend. Backendissä olen tyytyväinen
Three-point achitecture -malliin, joka on suurin piirtein seuraava:

DAO-tiedostot: Suorat sql-kyselyt,
BLA-tiedostot : nämä muuntaa DAO:sta saadut vastaukset JSONIKSI => Lopuksi esimerkiksi Stations.cs  muutta 
sen http-kutsumuotoon.


Endpoint:t muodostetaan kahdessa tiedostossa: stations.cs ja journeys.cs.
Huom! käyttöliittymän linkit pitää konfiguroida uudelleen, koska azure-ympäristöä ei minulla enää ole käytössä-




Antto Hautamäki
