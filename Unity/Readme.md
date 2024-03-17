# Hackathon Project: Integrated Sign in with World ID to Decentralized GPT Domain Names

This hackathon project showcases a unique and powerful integration of decentralized identity verification with domain management in the Web3 space, leveraging World ID, Unity, and Auth0 technologies.

## Project Overview

We've created a unique multi-chain domain naming system to unlock Web3 digital assets for brands, artists, and individuals. By integrating World ID for authentication, users can manage their Web3 domains and associated assets through an unparalleled UI/UX, developed using Unity. This strategic choice allows us to leverage Unity's rich graphical capabilities and robust development environment, creating a WebGL application that can be hosted in a decentralized manner for a user-friendly, immersive management experience of Web3 domains.

For more details on the event and prizes, visit [ETHGlobal London 2024](https://ethglobal.com/events/london2024/prizes/worldcoin).

## Qualification Requirements

To qualify for this project, participants must meet the following criteria:

- **Integration**: Implement Sign in with World ID or Incognito Actions.
- **World ID Integration**: Ensure full integration of World ID, with proof validation occurring in a web backend or smart contract.

## Integration of World ID

Integration was achieved through two key methods:

### 1. Auth0 Integration

Auth0 provides OAuth2 capabilities and supports adding Worldcoin as a provider. This method offers a standardized, secure way to manage user authentication and authorization, creating a World ID for each custom GPT created at the 3NS domain endpoints. Auth0 simplifies the management of user and bot identities and access controls across the Web3 domain naming system.
See code in `assets/scripts/worldcoincontroller.cs`.
 


### 2. Direct Unity Integration

 We explored direct integration from Unity to World ID to streamline the authentication process. This approach was conceived by manually implementing the OAuth2 flow in Unity. However, based on review and expert advice, Auth0 was selected as the preferred method for World ID integration, due to its robust security features and ease of implementation didn't pursue it further, however, you can see the implementation in 'assets/scripts/
 
 See code in `assets/scripts/worldcoinDirectcontroller.cs`.
 
 

## Code


You will find a Unity folder in the repo.

The Unity Project is in the folder called Unity

MY ASSETS UI 
/Scenes/* - here you will find the UI scenes that I created 
/Controllers/* - controllers for the scene
/Managers/* - component UI managers
/UI/* - Utility
WorldCoinController.cs - as described above
WorldCoinDirectController.cs - as described above

PLUGINS
/Assets/Auth0 - this is the Auth0 plugin for unity
/Assets/MetaMask - this is the Metamask plugin for unity



We are grateful for the opportunity to collaborate with the Worldcoin team and are excited about taking this project further within the grants program. The integration of World ID, accomplished in this hackathon, is just the beginning of our journey to unlock mass adoption and explore new opportunities in the Web3 space.

This project aligns with the shared mission of Worldcoin, marking a significant step forward in our collective endeavor to enhance security and user engagement in the digital domain.  We are excite by next steps.