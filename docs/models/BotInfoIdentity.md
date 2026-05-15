# Fingerprint.ServerSdk.Model.BotInfoIdentity
The verification status of the bot's identity:
 * `verified` - well-known bot with publicly verifiable identity, directed by the bot provider.
 * `signed` - bot that signs its platform via Web Bot Auth, directed by the bot provider's customers.
 * `spoofed` - bot that claims a public identity but fails verification.
 * `unknown` - bot that does not publish a verifiable identity.

