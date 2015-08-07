<strong>Project Description:</strong><br />
The BetfairDataClient prototype project is an attempt to make it easier for Betfair developers to build highly scalable and customisable systems against Betfair products and APIs.
It's developed in C# .NET 3.5
<br /><br />
This projects aims to design and build a robust data access layer to isolate the user code from the data structures derived from the API WSDLs.
<br /><br />
Most of us started using the Betfair SOAP API and for convenience sake ended up using the generated WSDL class structures throughout our applications/bots.
Those of us that have been using the API for a while know how painful it can be when something changes in the API, yet we still do it
<br /><br />
Lets face it, we don't really want to spend a whole lot of time dealing the API we just want to get the data, place the order. The stuff that interest us is our strategies and tweaking this that and the other, the less time spent on the API the better.
<br /><br />
So let’s figure out what our DAL should be and have
<br /><br />
1. Constant presentation to consumer classes regardless of data interface method (SOAP, REST, Carrier Pigeon etc.)<br />
2. Generic<br />
3. Provider business logic<br />
4. Caching mechanism<br />
5. Custom exception handling<br />
6. Event driven messaging<br />
7. Asynchronus<br />
8. Fast, very fast!<br />
<br />
<br />
Design considerations:
The BetfairDAL solution will be a collection of projects, the core BetfairDataClient assembly should ideally be Mono compliant.
<br />
Projects in the solution:
<br />
<strong>1) BetfairDataClient project (The business end)</strong>
- Mono compliant<br />
- Namespace Betfair.Data<br />
- base classes should be sealed i.e. sealed public MarketBase, Eventbase etc<br />
- Cache long lived data to disk using XML if enabled (SQL or other storage solutions belong at a higher level and is usually a custom implementation)<br />
- The interface inherited by the DataProvider is defined at this level (i.e. Betfair.DAL.Interfaces.ISport, Betfair.DAL.Interfaces.IAccount, Betfair.DAL.Interfaces.IGames and so on)<br />
<br />
<strong>2) MyBetairDataServer project</strong><br />
- Simple win forms or WPF front end to enable operation without IIS<br />
- User configureable protocols + ports<br />
- If we have time a simple Excel spreadsheet to consume the service (hopefully somebody can help us with that)<br />
- Start stop and monitor output<br />
- this consumes BetfairDataClient.dll <br />