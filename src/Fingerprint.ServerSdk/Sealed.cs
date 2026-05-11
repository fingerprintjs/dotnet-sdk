using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Fingerprint.ServerSdk.Client;
using Fingerprint.ServerSdk.Model;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;

namespace Fingerprint.ServerSdk
{
    public class Sealed
    {
        public enum DecryptionAlgorithm
        {
            Aes256Gcm
        }

        public class DecryptionKey
        {
            public byte[] Key { get; }
            public DecryptionAlgorithm Algorithm { get; }

            public DecryptionKey(byte[] key, DecryptionAlgorithm algorithm)
            {
                Key = key;
                Algorithm = algorithm;
            }
        }

        public class UnsealAggregateException : Exception
        {
            public List<UnsealException> UnsealExceptions { get; } = new();

            public UnsealAggregateException() : base("Failed to unseal with all decryption keys")
            {
            }

            public void AddUnsealException(UnsealException exception)
            {
                UnsealExceptions.Add(exception);
            }
        }

        public class InvalidSealedDataException : ArgumentException
        {
            public InvalidSealedDataException() : base("Invalid sealed data")
            {
            }
        }

        public class InvalidSealedDataHeaderException : ArgumentException
        {
            public InvalidSealedDataHeaderException() : base("Invalid sealed data header")
            {
            }
        }

        public class UnsealException : Exception
        {
            public DecryptionKey DecryptionKey { get; }
            public new Exception InnerException { get; }

            public UnsealException(string message, DecryptionKey decryptionKey, Exception exception) : base(message, exception)
            {
                DecryptionKey = decryptionKey;
                InnerException = exception;
            }
        }

        private static readonly byte[] SealHeader = { 0x9E, 0x85, 0xDC, 0xED };
        private const int _nonceLength = 12;
        private const int _authTagLength = 16;

        public static byte[] Unseal(byte[] sealedData, DecryptionKey[] keys)
        {
            if (!sealedData.Take(SealHeader.Length).SequenceEqual(SealHeader))
            {
                throw new InvalidSealedDataHeaderException();
            }

            var aggregateException = new UnsealAggregateException();

            foreach (var key in keys)
            {
                switch (key.Algorithm)
                {
                    case DecryptionAlgorithm.Aes256Gcm:
                        try
                        {
                            return DecryptAes256Gcm(sealedData.Skip(SealHeader.Length).ToArray(), key.Key);
                        }
                        catch (Exception exception)
                        {
                            aggregateException.AddUnsealException(new UnsealException("Failed to decrypt", key, exception));
                        }
                        break;

                    default:
                        throw new ArgumentException("Invalid decryption algorithm");
                }
            }

            throw aggregateException;
        }

        /// <summary>
        /// Decrypts the sealed response with the provided keys.
        /// </summary>
        /// <value>An decrypted instance of the EventResponse.</value>
        /// <remarks>
        /// The SDK will try to decrypt the result with each key until it succeeds.
        /// </remarks>
        public static Event UnsealEventResponse(byte[] sealedData, DecryptionKey[] keys)
        {
            var unsealed = Unseal(sealedData, keys);

            var json = Encoding.UTF8.GetString(unsealed);
            var value = JsonSerializer.Deserialize<Event>(json, GetJsonSerializerOptions());

            if (value == null)
            {
                throw new InvalidSealedDataException();
            }

            return value;
        }

        private static byte[] DecryptAes256Gcm(byte[] sealedData, byte[] key)
        {
            var nonce = sealedData.Take(_nonceLength).ToArray();
            var cipherText = sealedData.Skip(_nonceLength).ToArray();

            var cipher = new GcmBlockCipher(new AesEngine());
            var parameters = new AeadParameters(new KeyParameter(key), _authTagLength * 8, nonce);
            cipher.Init(false, parameters);

            var output = new byte[cipher.GetOutputSize(cipherText.Length)];
            var len = cipher.ProcessBytes(cipherText, 0, cipherText.Length, output, 0);
            cipher.DoFinal(output, len);

            return Decompress(output);
        }


        private static byte[] Decompress(byte[] data)
        {
            using (var compressedStream = new MemoryStream(data))
            {
                using (var deflateStream = new DeflateStream(compressedStream, CompressionMode.Decompress))
                {
                    using (var resultStream = new MemoryStream())
                    {
                        deflateStream.CopyTo(resultStream);
                        return resultStream.ToArray();
                    }
                }
            }
        }

        private static JsonSerializerOptions GetJsonSerializerOptions()
        {
            var jsonOptions = new JsonSerializerOptions();
            jsonOptions.Converters.Add(new JsonStringEnumConverter());
            jsonOptions.Converters.Add(new DateTimeJsonConverter());
            jsonOptions.Converters.Add(new DateTimeNullableJsonConverter());
            jsonOptions.Converters.Add(new BotInfoJsonConverter());
            jsonOptions.Converters.Add(new BotResultJsonConverter());
            jsonOptions.Converters.Add(new BotResultNullableJsonConverter());
            jsonOptions.Converters.Add(new BrowserDetailsJsonConverter());
            jsonOptions.Converters.Add(new CanvasJsonConverter());
            jsonOptions.Converters.Add(new EmojiJsonConverter());
            jsonOptions.Converters.Add(new ErrorJsonConverter());
            jsonOptions.Converters.Add(new ErrorCodeJsonConverter());
            jsonOptions.Converters.Add(new ErrorCodeNullableJsonConverter());
            jsonOptions.Converters.Add(new ErrorResponseJsonConverter());
            jsonOptions.Converters.Add(new EventJsonConverter());
            jsonOptions.Converters.Add(new EventRuleActionJsonConverter());
            jsonOptions.Converters.Add(new EventRuleActionAllowJsonConverter());
            jsonOptions.Converters.Add(new EventRuleActionBlockJsonConverter());
            jsonOptions.Converters.Add(new EventSearchJsonConverter());
            jsonOptions.Converters.Add(new EventUpdateJsonConverter());
            jsonOptions.Converters.Add(new FontPreferencesJsonConverter());
            jsonOptions.Converters.Add(new GeolocationJsonConverter());
            jsonOptions.Converters.Add(new GeolocationSubdivisionsInnerJsonConverter());
            jsonOptions.Converters.Add(new IPBlockListJsonConverter());
            jsonOptions.Converters.Add(new IPInfoJsonConverter());
            jsonOptions.Converters.Add(new IPInfoV4JsonConverter());
            jsonOptions.Converters.Add(new IPInfoV6JsonConverter());
            jsonOptions.Converters.Add(new IdentificationJsonConverter());
            jsonOptions.Converters.Add(new IdentificationConfidenceJsonConverter());
            jsonOptions.Converters.Add(new IncrementalIdentificationStatusJsonConverter());
            jsonOptions.Converters.Add(new IncrementalIdentificationStatusNullableJsonConverter());
            jsonOptions.Converters.Add(new IntegrationJsonConverter());
            jsonOptions.Converters.Add(new IntegrationSubintegrationJsonConverter());
            jsonOptions.Converters.Add(new PluginsInnerJsonConverter());
            jsonOptions.Converters.Add(new PluginsInnerMimeTypesInnerJsonConverter());
            jsonOptions.Converters.Add(new ProximityJsonConverter());
            jsonOptions.Converters.Add(new ProxyConfidenceJsonConverter());
            jsonOptions.Converters.Add(new ProxyConfidenceNullableJsonConverter());
            jsonOptions.Converters.Add(new ProxyDetailsJsonConverter());
            jsonOptions.Converters.Add(new RareDevicePercentileBucketJsonConverter());
            jsonOptions.Converters.Add(new RareDevicePercentileBucketNullableJsonConverter());
            jsonOptions.Converters.Add(new RawDeviceAttributesJsonConverter());
            jsonOptions.Converters.Add(new RequestHeaderModificationsJsonConverter());
            jsonOptions.Converters.Add(new RuleActionHeaderFieldJsonConverter());
            jsonOptions.Converters.Add(new RuleActionTypeJsonConverter());
            jsonOptions.Converters.Add(new RuleActionTypeNullableJsonConverter());
            jsonOptions.Converters.Add(new SDKJsonConverter());
            jsonOptions.Converters.Add(new SearchEventsBotJsonConverter());
            jsonOptions.Converters.Add(new SearchEventsBotNullableJsonConverter());
            jsonOptions.Converters.Add(new SearchEventsEndParameterJsonConverter());
            jsonOptions.Converters.Add(new SearchEventsIncrementalIdentificationStatusJsonConverter());
            jsonOptions.Converters.Add(new SearchEventsIncrementalIdentificationStatusNullableJsonConverter());
            jsonOptions.Converters.Add(new SearchEventsRareDevicePercentileBucketJsonConverter());
            jsonOptions.Converters.Add(new SearchEventsRareDevicePercentileBucketNullableJsonConverter());
            jsonOptions.Converters.Add(new SearchEventsSdkPlatformJsonConverter());
            jsonOptions.Converters.Add(new SearchEventsSdkPlatformNullableJsonConverter());
            jsonOptions.Converters.Add(new SearchEventsStartParameterJsonConverter());
            jsonOptions.Converters.Add(new SearchEventsVpnConfidenceJsonConverter());
            jsonOptions.Converters.Add(new SearchEventsVpnConfidenceNullableJsonConverter());
            jsonOptions.Converters.Add(new SupplementaryIDHighRecallJsonConverter());
            jsonOptions.Converters.Add(new TamperingConfidenceJsonConverter());
            jsonOptions.Converters.Add(new TamperingConfidenceNullableJsonConverter());
            jsonOptions.Converters.Add(new TamperingDetailsJsonConverter());
            jsonOptions.Converters.Add(new TouchSupportJsonConverter());
            jsonOptions.Converters.Add(new VelocityJsonConverter());
            jsonOptions.Converters.Add(new VelocityDataJsonConverter());
            jsonOptions.Converters.Add(new VpnConfidenceJsonConverter());
            jsonOptions.Converters.Add(new VpnConfidenceNullableJsonConverter());
            jsonOptions.Converters.Add(new VpnMethodsJsonConverter());
            jsonOptions.Converters.Add(new WebGlBasicsJsonConverter());
            jsonOptions.Converters.Add(new WebGlExtensionsJsonConverter());

            return jsonOptions;
        }
    }
}