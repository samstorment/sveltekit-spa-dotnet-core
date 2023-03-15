<script lang="ts">
    // global css should be imported in the root layout https://github.com/sveltejs/kit/issues/3127#issuecomment-1225840065
    import '../global.css';
</script>

<nav>
    <a href="/">Home</a>
    <a href="/about">About</a>
    <p>A nav bar that exists on all pages</p>
</nav>

<main>
    <slot />
</main>

<style>
    nav {
        display: flex;
        padding: 1rem;
        gap: 1rem;
        border-bottom: 1px solid gray;
        align-items: center;
    }

    p {
        margin-left: auto;
    }

    main {
        padding: 1rem;
    }
</style>