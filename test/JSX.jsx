import React from 'react'


const Component = () =>
  <>
    <div>Something 1</div>
    <div>Something 2</div>
  </>


export const Main = () =>
  <div>
    <Component a="text" />
    <Component b=1 />
  </div>
