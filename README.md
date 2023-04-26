# ASP.NET Core Web Server + SvelteKit SPA


## Server Setup

Use Visual Studio to create ASP.NET Core Web App with .NET 7.0

Add the following packages

* Microsoft.AspNetCore.SpaServices
* Microsoft.AspNetCore.SpaServices.Extensions

Update Program.cs to work with Spa by adding the following lines

```csharp
builder.Services.AddSpaStaticFiles(config => {
	// you can name this whatever you'd like, but it needs to match the name of the directory you use with the adapter-static pages and assets
	config.RootPath = "client/build";
});

app.UseSpaStaticFiles();
```


## Client Setup

In the same directory as the Server run:

```bash
# Client is directory name for your project
npm create svelte@latest Client
cd Client
npm install
# to test things worked properly
npm run dev
```
### Adapter Static

[Github](https://github.com/sveltejs/kit/tree/master/packages/adapter-static#spa-mode) and [Documentation](https://kit.svelte.dev/docs/adapter-static)

Install svelte-adapter-static

```bash
npm i -D @sveltejs/adapter-static
```

Update the adapter in the svelte config file

```js
// svelte.config.js
import adapter from '@sveltejs/adapter-static';

export default {
	kit: {
		adapter: adapter({
			fallback: '200.html',
			prerender: { entries: [] },
			// Automatically build pages and assets to the client/build directory located in our ASP.NET Core Web App
			// Change the directory names if you picked a different directory for config.RootPath when calling `builder.Services.AddSpaStaticFiles` on your server
			pages: '../Server/Server/client/build',
			assets: '../Server/Server/client/build'
		})
	}
};
```

Create `src/routes/+layout.ts` and set ssr to false

```js
// src/routes/+layout.ts
export const ssr = false;
```

Run `npm run build` to build client app. Files should output in `../Server/Server/client/build`