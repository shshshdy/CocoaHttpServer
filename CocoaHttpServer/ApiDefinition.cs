using System;
using Foundation;
using ObjCRuntime;

namespace CocoaHttpServer
{
	// @interface HTTPServer : NSObject <NSNetServiceDelegate>
	[BaseType(typeof(NSObject))]
	interface HTTPServer : INSNetServiceDelegate
	{
		// -(NSString *)documentRoot;
		// -(void)setDocumentRoot:(NSString *)value;
		[Export("documentRoot")]
		string DocumentRoot();
		[Export("setDocumentRoot:")]
		void SetDocumentRoot(string value);

		// -(Class)connectionClass;
		[Export("connectionClass")]
		Class ConnectionClass();

		// -(void)setConnectionClass:(Class)value;
		[Export("setConnectionClass:")]
		void SetConnectionClass(Class value);

		// -(NSString *)interface;
		[Export("interface")]
		string Interface();

		// -(void)setInterface:(NSString *)value;
		[Export("setInterface:")]
		void SetInterface(string value);

		// -(UInt16)port;
		[Export("port")]
		ushort Port();

		// -(UInt16)listeningPort;
		[Export("listeningPort")]
		ushort ListeningPort();

		// -(void)setPort:(UInt16)value;
		[Export("setPort:")]
		void SetPort(ushort value);

		// -(NSString *)domain;
		[Export("domain")]
		string Domain();

		// -(void)setDomain:(NSString *)value;
		[Export("setDomain:")]
		void SetDomain(string value);

		// -(NSString *)name;
		[Export("name")]
		string Name();

		// -(NSString *)publishedName;
		[Export("publishedName")]
		string PublishedName();

		// -(void)setName:(NSString *)value;
		[Export("setName:")]
		void SetName(string value);

		// -(NSString *)type;
		[Export("type")]
		string Type();

		// -(void)setType:(NSString *)value;
		[Export("setType:")]
		void SetType(string value);

		// -(void)republishBonjour;
		[Export("republishBonjour")]
		void RepublishBonjour();

		// -(NSDictionary *)TXTRecordDictionary;
		[Export("TXTRecordDictionary")]
		NSDictionary TXTRecordDictionary();

		// -(void)setTXTRecordDictionary:(NSDictionary *)dict;
		[Export("setTXTRecordDictionary:")]
		void SetTXTRecordDictionary(NSDictionary dict);

		// -(BOOL)start:(NSError **)errPtr port:(void (^)(NSString *, NSString *))port;
		[Export("start:port:")]
		bool Start(out NSError errPtr, Action<NSString, NSString> port);

		// -(void)stop;
		[Export("stop")]
		void Stop();

		// -(void)stop:(BOOL)keepExistingConnections;
		[Export("stop:")]
		void Stop(bool keepExistingConnections);

		// -(BOOL)isRunning;
		[Export("isRunning")]
		bool IsRunning();

		// -(NSUInteger)numberOfHTTPConnections;
		[Export("numberOfHTTPConnections")]
		nuint NumberOfHTTPConnections();

		// -(NSUInteger)numberOfWebSocketConnections;
		[Export("numberOfWebSocketConnections")]
		nuint NumberOfWebSocketConnections();
	}
}
