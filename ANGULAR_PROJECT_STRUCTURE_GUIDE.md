# Angular Project Structure Guide

This document defines the clean, enterprise-style Angular structure to follow before creating the project.

## Goal

Create a small Angular application with modular architecture, scalable folder separation, and a clear setup for routing, shared logic, feature modules, styling, and state management.

## Recommended folder structure

```text
src/
  app/
    app-routing.module.ts
    app.component.ts
    app.component.html
    app.component.scss
    app.config.ts
    app.module.ts   // if using NgModule structure

    core/
      auth/
      config/
      guards/
      interceptors/
      models/
      services/
      utils/

    shared/
      components/
      directives/
      pipes/
      ui/
      helpers/

    features/
      dashboard/
        dashboard-routing.module.ts
        dashboard.module.ts
        dashboard.component.ts
        dashboard.component.html
        dashboard.component.scss
      products/
        products-routing.module.ts
        products.module.ts
        products.component.ts
      settings/
        settings-routing.module.ts
        settings.module.ts
      ...

  assets/
    images/
    icons/

  styles/
    themes/
      _default-theme.scss
      _dark-theme.scss
    abstracts/
      _variables.scss
      _mixins.scss
    base/
      _reset.scss
      _typography.scss
    main.scss
```

## Architecture principles

### 1. App shell first
- Create the Angular project with routing enabled.
- Add SCSS support from the start.
- Build the root app shell: root module, root routing, and root component.

### 2. Separate responsibilities
- `core/`: application-wide singleton services, config loading, interceptors, guards, models, and initialization logic.
- `shared/`: reusable UI components, pipes, directives, helper utilities, and presentation logic used across features.
- `features/`: domain-specific modules and pages that can be lazy-loaded.
- `styles/`: global styles, theme files, variables, and shared CSS utilities.

### 3. Routing and lazy loading
- Use feature modules and lazy-load them through the main router.
- Keep route configuration clear and modular.
- Load feature areas only when needed.

### 4. HTTP and app startup
- Add a global HTTP interceptor for:
  - headers
  - auth tokens
  - loading indicators
  - error handling
- Add an initializer service to load configuration on app startup.

### 5. State management approach
- Use Angular signals for local component state.
- Use RxJS streams for async data flows and side effects.
- Add `ComponentStore` only when a feature has complex state logic and benefits from a dedicated store.

### 6. Styling system
- Create global SCSS files for the base app theme.
- Keep them separated for readability and maintainability.
- Use variables, mixins, and theme files for consistent styling.

### 7. Testing baseline
- Add basic tests for:
  - routing
  - interceptors
  - auth guards
  - shared services

## Proposed Angular CLI setup

```bash
ng new my-angular-app --routing --style=scss
```

Then organize the files after scaffolding into the structure above.

## Recommended module plan

### Core layer
Use this folder for application-wide concerns:
- config loading
- authentication
- interceptors
- guards
- models
- singleton services

### Shared layer
Use this folder for reusable elements:
- cards
- buttons
- forms
- pipes
- directives
- helper functions

### Feature layer
Use this folder for the business domains:
- dashboard
- users
- products
- settings
- reports

## Summary

This structure keeps the application easy to scale, clear to navigate, and consistent with modern Angular enterprise conventions.

The next step is to scaffold the Angular project and then implement the folders and initial app shell based on this guide.
