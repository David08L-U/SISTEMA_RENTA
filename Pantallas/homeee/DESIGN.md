---
name: Executive Stays
colors:
  surface: '#f7f9ff'
  surface-dim: '#d7dadf'
  surface-bright: '#f7f9ff'
  surface-container-lowest: '#ffffff'
  surface-container-low: '#f1f4f9'
  surface-container: '#ebeef3'
  surface-container-high: '#e5e8ee'
  surface-container-highest: '#e0e3e8'
  on-surface: '#181c20'
  on-surface-variant: '#424655'
  inverse-surface: '#2d3135'
  inverse-on-surface: '#eef1f6'
  outline: '#727787'
  outline-variant: '#c2c6d8'
  surface-tint: '#0057ce'
  primary: '#0057cd'
  on-primary: '#ffffff'
  primary-container: '#0d6efd'
  on-primary-container: '#ffffff'
  inverse-primary: '#b1c5ff'
  secondary: '#575f67'
  on-secondary: '#ffffff'
  secondary-container: '#d8e1ea'
  on-secondary-container: '#5b646b'
  tertiary: '#006b29'
  on-tertiary: '#ffffff'
  tertiary-container: '#008735'
  on-tertiary-container: '#f7fff2'
  error: '#ba1a1a'
  on-error: '#ffffff'
  error-container: '#ffdad6'
  on-error-container: '#93000a'
  primary-fixed: '#dae2ff'
  primary-fixed-dim: '#b1c5ff'
  on-primary-fixed: '#001946'
  on-primary-fixed-variant: '#00419e'
  secondary-fixed: '#dbe4ed'
  secondary-fixed-dim: '#bfc8d0'
  on-secondary-fixed: '#141d23'
  on-secondary-fixed-variant: '#3f484f'
  tertiary-fixed: '#69ff87'
  tertiary-fixed-dim: '#3ce36a'
  on-tertiary-fixed: '#002108'
  on-tertiary-fixed-variant: '#00531e'
  background: '#f7f9ff'
  on-background: '#181c20'
  surface-variant: '#e0e3e8'
typography:
  headline-xl:
    fontFamily: Inter
    fontSize: 48px
    fontWeight: '700'
    lineHeight: '1.2'
    letterSpacing: -0.02em
  headline-lg:
    fontFamily: Inter
    fontSize: 32px
    fontWeight: '700'
    lineHeight: '1.25'
    letterSpacing: -0.01em
  headline-lg-mobile:
    fontFamily: Inter
    fontSize: 28px
    fontWeight: '700'
    lineHeight: '1.25'
  headline-md:
    fontFamily: Inter
    fontSize: 24px
    fontWeight: '600'
    lineHeight: '1.3'
  body-lg:
    fontFamily: Inter
    fontSize: 18px
    fontWeight: '400'
    lineHeight: '1.6'
  body-md:
    fontFamily: Inter
    fontSize: 16px
    fontWeight: '400'
    lineHeight: '1.5'
  label-md:
    fontFamily: Inter
    fontSize: 14px
    fontWeight: '600'
    lineHeight: '1.4'
    letterSpacing: 0.05em
  label-sm:
    fontFamily: Inter
    fontSize: 12px
    fontWeight: '500'
    lineHeight: '1.4'
rounded:
  sm: 0.25rem
  DEFAULT: 0.5rem
  md: 0.75rem
  lg: 1rem
  xl: 1.5rem
  full: 9999px
spacing:
  base: 8px
  container-max: 1320px
  gutter: 1.5rem
  section-padding-desktop: 80px
  section-padding-mobile: 40px
---

## Brand & Style
The design system is engineered for a premium Corporate Apartment Rental platform, targeting business professionals and HR procurement teams. The brand personality is efficient, reliable, and sophisticated. 

The visual style follows a **Corporate Modern** aesthetic—a refinement of Bootstrap 5 principles. It prioritizes clarity and high-signal information density without feeling cluttered. By utilizing a restrained color palette and generous whitespace, the UI evokes a sense of calm and institutional trust, ensuring that the property data remains the primary focus.

## Colors
The palette is rooted in a deep, professional blue that signals authority and stability. 

- **Primary:** Corporate Blue (#0D6EFD) for primary actions, branding, and active states.
- **Surface:** The interface rests on a cool light gray (#F8F9FA) background to differentiate from pure white (#FFFFFF) card containers.
- **Typography:** Dark charcoal (#212529) provides high contrast and maximum legibility for body text and headers.
- **Semantic/Status:** 
    - **Green (#198754):** Available.
    - **Red (#DC3545):** Rented/Occupied.
    - **Yellow (#FFC107):** Maintenance/Pending.

## Typography
This design system utilizes **Inter** as a systematic, utilitarian typeface. It excels in data-heavy environments due to its tall x-height and excellent legibility.

- **Headlines:** Use Bold (700) weights with slight negative letter-spacing for a modern, "tucked" look in titles.
- **Body:** Regular (400) weight for long-form reading, switching to Medium (500) for UI labels.
- **Scalability:** Large headlines (XL and LG) should scale down on mobile to prevent awkward line breaks in property titles.

## Layout & Spacing
The layout follows a **Fluid Grid** model based on the standard 12-column system. 

- **Grid:** Use a 24px (1.5rem) gutter to provide breathing room between property cards and data columns.
- **Margins:** Desktop views should maintain a maximum container width of 1320px for optimal readability.
- **Rhythm:** Spacing follows an 8px base unit. Component internal padding should strictly adhere to multiples of 8 (8, 16, 24, 32) to ensure vertical and horizontal alignment across complex dashboards.

## Elevation & Depth
To move beyond a "stock" Bootstrap look, this design system uses **Ambient Shadows** to create a sophisticated sense of depth.

- **Flat Base:** Backgrounds are kept flat (#F8F9FA).
- **Elevated Cards:** Property cards and modal dialogs use a multi-layered shadow (0px 10px 15px -3px rgba(0,0,0,0.1)) to appear gently lifted from the surface.
- **Interactive Depth:** Buttons should use a subtle inset shadow on 'active' states to simulate a physical press, while 'hover' states should slightly increase the shadow spread.

## Shapes
The design system adopts a **Rounded** (rounded-3) approach to soften the corporate edge and make the UI feel approachable.

- **Standard Elements:** Buttons, input fields, and cards utilize a 0.5rem (8px) corner radius.
- **Large Containers:** Modals and large feature sections may use `rounded-xl` (1.5rem) to signify a distinct content area.
- **Icons:** Use FontAwesome icons with a "Regular" or "Light" weight to maintain a clean, thin-stroke aesthetic that complements the Inter typeface.

## Components
Consistent component styling ensures the platform feels like a cohesive tool for professional use.

- **Buttons:** Primary buttons use the Corporate Blue background with white text. They should have a subtle 2px transition on hover.
- **Status Badges:** Use a pill-shaped geometry (`rounded-pill`). These must be high-contrast: white text on the semantic background (Green/Red/Yellow).
- **Cards:** The primary container for property listings. Use a white background, 1px border (#DEE2E6), and the ambient shadow defined in the Elevation section.
- **Input Fields:** Use a 1px solid border (#CED4DA). On focus, the border transitions to Corporate Blue with a 0.25rem semi-transparent blue glow (ring).
- **Lists:** Dashboard lists should use a "Zebra-stripe" pattern or thin horizontal dividers (#DEE2E6) to help eyes track data across wide screens.
- **Availability Calendar:** A custom component using a light grid where "Rented" dates are marked with a diagonal strike-through and a light red fill.