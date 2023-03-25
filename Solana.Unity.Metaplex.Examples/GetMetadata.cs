using Solana.Unity.Metaplex;
using Solana.Unity.Wallet;
using Solana.Unity.Rpc;
using System;
using Solana.Unity.Metaplex.NFT.Library;
using System.Threading.Tasks;

namespace Solana.Unity.Metaplex.Examples
{


public class GetMetadataExample : IRunnableExample
{
    string pk = "5CEeeHkyezrVpexdKjGkMv18dDRRW2tbF45yr5YfmAHt";
    public async Task Run()
    {
        Console.WriteLine("### Get Metadata example ###");
        Console.WriteLine("Getting account {0}", pk );

        var client = ClientFactory.GetClient( Cluster.MainNet);
        var account = await MetadataAccount.GetAccount( client, new PublicKey(pk ));

        Console.WriteLine( $"Owner: {account.owner}");
        Console.WriteLine( $"Authority key: {account.updateAuthority}");
        Console.WriteLine( $"Mint key: {account.mint}");
        Console.WriteLine( $"Name: {account.metadata.name}");
        Console.WriteLine( $"Symbol: {account.metadata.symbol}");
        Console.WriteLine( $"Uri: {account.metadata.uri}");
        Console.WriteLine( $"SellerFeeBasisPoints: {account.metadata.sellerFeeBasisPoints}");

        Console.WriteLine( $"---Creators---");
        foreach( Creator c in account.metadata.creators)
        {
            Console.WriteLine( $"Creator Key: {c.key}");
            Console.WriteLine( $"Creator Share: {c.share}");
            Console.WriteLine( $"Creator is verified: {c.verified}");
        }

        Console.WriteLine(  "-------Metadata-------");
        Console.WriteLine($"Name: {account.offchainData.name}");
        Console.WriteLine($"Description: {account.offchainData.description}");
        Console.WriteLine($"Symbol: {account.offchainData.symbol}");
        Console.WriteLine($"Collection: {account.offchainData.collection}");
        Console.WriteLine($"Default Image: { account.offchainData.default_image }" );
        Console.WriteLine($"Animation url: {account.offchainData.animation_url}");

        foreach (var attribute in account.offchainData.attributes)
        {
            if(attribute != null)
               Console.WriteLine($"Attribute: { attribute.trait_type } | { attribute.value }");

        }

        Console.WriteLine ( "------------------");
    }
}



}